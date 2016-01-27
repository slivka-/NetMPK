using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMPK
{
    public static class StopsSearch
    {
        private static DatabaseConnection DBConn;

        public static String searchForStop(String stopName)
        {
            DBConn = DatabaseConnection.getInstance();
            DBConn.OpenConnection();
            List<String> StopsList = DBConn.GetLinesStopNames();
            DBConn.CloseConnection();
            String output = "";
            Double lastMatch = 0;
            foreach (String s in StopsList)
            {
                if (s.Length == stopName.Length)
                {
                    char[] s1 = s.ToArray();
                    char[] s2 = stopName.ToArray();
                    int eqCounter = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s1[i] == s2[i])
                        {
                            eqCounter++;
                        }
                    }
                    Double match = ((Double)eqCounter / (Double)s.Length) * 100;
                    System.Diagnostics.Debug.WriteLine(eqCounter);
                    System.Diagnostics.Debug.WriteLine(match);
                    if (match >= 60 && match > lastMatch)
                    {
                        lastMatch = match;
                        output = s;
                    }
                }

            }
            return output;

        }
                        
                        
        
    }
}