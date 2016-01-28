using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMPK
{
    public class Pathfinding
    {
        public List<Node> Nodes { get; set; }
        //distance
        int[] d;
        //previous
        int[] p;
        int e;
        int n;
        int source;
        int stop;
        const int INFINITY = 9999;
        DatabaseConnection connection = DatabaseConnection.getInstance();
        Dictionary<int, string> idToName;

        public List<string> FindConnection(string stopStart, string stopEnd)
        {
            if (!ValidateUserInput(stopStart, stopEnd))
                throw new ArgumentException("Złe nazwy przystanków");

            InitializeNodes();
            InitializeVariables(stopStart, stopEnd);
            return Find(); 
        }

        private void InitializeVariables(string stopStart, string stopEnd)
        {
            source = connection.GetIDFromStopName(stopStart); //Source vertex
            stop = connection.GetIDFromStopName(stopEnd);
            e = Nodes.Count;
            d = new int[n + 1];
            p = new int[n + 1];
        }

        private bool ValidateUserInput(string stopStart, string stopEnd)
        {
            if (string.IsNullOrEmpty(stopStart))
                return false;
            if (string.IsNullOrEmpty(stopEnd))
                return false;
            if (!connection.CheckIfExists(stopStart))
                return false;
            if (!connection.CheckIfExists(stopEnd))
                return false;
            return true;
        }

        private void InitializeNodes()
        {
            idToName = new Dictionary<int, string>();
            Nodes = new List<Node>();
            List<int> stopsID = connection.GetAllStopsID();
            for (int i = 0; i < stopsID.Count; ++i)
            {
                idToName.Add(stopsID[i], connection.GetStopNameFromID(stopsID[i]));
            }
            //n to liczba przystanków
            n = connection.GetStopCount();
            for (int i = 0; i < n; ++i)
            {
                List<int> connections = connection.GetAllToStopID(stopsID[i]);
                for (int j = 0; j < connections.Count; ++j)
                {
                    // U- przystanek z (stopsID[i]?)
                    //V- przystanek do (connections[j]?)
                    //W - waga (czas pomiedzy U i V- nowa komenda?)
                    //getTimeFromConnection(u, v)- i to ma być int

                    Nodes.Add(new Node(stopsID[i], connections[j], connection.GetTimeFromConnection(stopsID[i], connections[j])));
                    Nodes.Add(new Node(connections[j], stopsID[i], connection.GetTimeFromConnection(stopsID[i], connections[j])));
                }
            }
        }

        public void Relax()
        {
            int i, j;
            for (i = 0; i < n+1; ++i)
            {
                d[i] = INFINITY;
                p[i] = -1;
            }

            d[source] = 0;
            for (i = 0; i < n - 1; ++i)
            {
                for (j = 0; j < e; ++j)
                {
                    if (d[Nodes[j].U] + Nodes[j].W < d[Nodes[j].V])
                    {
                        d[Nodes[j].V] = d[Nodes[j].U] + Nodes[j].W;
                        p[Nodes[j].V] = Nodes[j].U;
                    }
                }
            }
        }

        private List<string> Find()
        {
            List<string> result = new List<string>();
            Relax();
            int timeTotal = 0;
            int current = stop;
            while (current != source)
            {
                string pierwszy = idToName[current];
                string drugi;
                if (p[p[current]] == -1)
                {
                    drugi = idToName[source];
                }
                else
                {
                    drugi = idToName[p[current]];
                }
                int currentTime = connection.GetTimeFromConnection(current, p[current]);
                timeTotal += currentTime;
                result.Add(drugi + " jedzie na " + pierwszy + " |czas przejazdu: " + currentTime + " min." + " |linia: " + connection.GetLineFromConnection(current, p[current]));
                current = p[current];
            }

            List<string> temp = new List<string>();
            for (int i = result.Count - 1; i >= 0; --i)
                temp.Add(result[i]);

            TimeSpan span = TimeSpan.FromMinutes(timeTotal);
            temp.Add("Całkowity czas przejazdu: " + span.ToString("hh':'mm"));
            return temp;
        }
    }
}