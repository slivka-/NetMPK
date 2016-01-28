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

            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().userVerified)
                {
                    routeSaveBtn.Visible = false;
                    String routeSource = Request.QueryString["firstStop"];
                    String routeEnd = Request.QueryString["lastStop"];
                    if (routeSource != null && routeEnd != null)
                    {
                        sourceStop.Text = routeSource;
                        endStop.Text = routeEnd;
                        searchTrack(routeSource, routeEnd);
                    }
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
            string source = sourceStop.Text;
            string end = endStop.Text;
            searchTrack(source, end);
        }

        private void searchTrack(String source, String end)
        {
            Pathfinding p = new Pathfinding();
            List<string> result;
            try
            {
                mainContent.InnerHtml = "";
                result = p.FindConnection(source, end);
                for (int i = 0; i < result.Count - 1; ++i)
                {
                    mainContent.InnerHtml += i + 1 + ":  " + result[i] + "</br>";
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

            String _routeStart = sourceStop.Text;
            String _routeEnd = endStop.Text;
            Response.Redirect("~/Account/UserSite.aspx?firstStop=" + _routeStart + "&lastStop="+_routeEnd);
        }
    }
}