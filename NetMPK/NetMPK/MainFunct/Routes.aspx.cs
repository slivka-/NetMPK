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
            Pathfinding p = new Pathfinding();
            //p.FindConnection("a", "b");
            //List<Node> t = p.Nodes;
            int counter = 0;
            List<string> result = p.Test();
            //foreach (var n in t)
            //{
            //    mainContent.InnerHtml += counter + ":  " + n.U + " - " + n.V + " w: " + n.W + "</br>";
            //    counter++;
            //}

            foreach (var n in result)
            {
                mainContent.InnerHtml += counter + ":  " + n + "</br>";
                counter++;
            }
        }
    }
}