using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class Routes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void routeSearchButton_Click(object sender, EventArgs e)
        {
            Pathfinding p = new Pathfinding();
            string source = sourceStop.Text;
            string end = endStop.Text;
            List<string> result;
            try
            {
                mainContent.InnerHtml = "";
                result = p.FindConnection(source, end);
                int counter = 1;
                foreach (var n in result)
                {
                    mainContent.InnerHtml += counter + ":  " + n + "</br>";
                    counter++;
                }
            }
            catch (ArgumentException ae)
            {
                mainContent.InnerHtml += @"Nie można znaleźć trasy pomiędzy wybranymi przystankami.
                                        Upewnij się, że są poprawne";//ae.Message + "</br>";
            }
        }
    }
}