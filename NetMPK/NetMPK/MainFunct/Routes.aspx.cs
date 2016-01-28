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
        public String _routeStart ="";
        public String _routeEnd = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().userVerified)
                {
                    routeSaveBtn.Visible = false;
                }
                else
                {
                    Response.Redirect("~/Account/ConfirmAccount.aspx");
                }
            }
            else
            {
                Response.Redirect("~/MainFunct/NotLoggedIn.aspx");

            }
        }

        protected void routeSearchButton_Click(object sender, EventArgs e)
        {
            Pathfinding p = new Pathfinding();
            string source = sourceStop.Text;
            string end = endStop.Text;
            _routeStart = sourceStop.Text;
            _routeEnd = endStop.Text;
            System.Diagnostics.Debug.WriteLine(source);
            System.Diagnostics.Debug.WriteLine(end);
            List<string> result;
            try
            {
                mainContent.InnerHtml = "";
                result = p.FindConnection(source, end);
                for(int i = 0; i < result.Count-1; ++i)
                {
                    mainContent.InnerHtml += i+1 + ":  " + result[i] + "</br>";
                }
                mainContent.InnerHtml += result[result.Count - 1];
                //mainContent.InnerHtml += " </br><a runat=\"server\"  class = \"btn btn-default\" href=\"Account/UserSite.aspx?firstStop=" + source + "&lastStop="+end+"\">Zapisz trasę</a></br></br>";
                
                routeSaveBtn.Visible = true;
            }
            catch (ArgumentException ae)
            {
                mainContent.InnerHtml += @"Nie można znaleźć trasy pomiędzy wybranymi przystankami.
                                        Upewnij się, że są poprawne";//ae.Message + "</br>";

            }
        }

        protected void routeSaveButton(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/UserSite.aspx?firstStop=" + _routeStart + "&lastStop="+_routeEnd);
        }
    }
}