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
                    //KOD
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
                //mainContent.InnerHtml += " </br><a runat=\"server\"  class = \"btn btn-default\" OnClick=\"SaveRouteButton_Click\" >Zapisz trasę</a></br></br>";
                //mainContent.InnerHtml += @"<asp:Button runat=""server"" OnClick=""SaveRouteButton_Click"" Text=""Zapisz"" />";
                mainContent.InnerHtml += "</br><button type=\"button\" runat=\"server\"  OnClick=\"SaveRouteButton_Click\">Zapisz</button>";
            }
            catch (ArgumentException ae)
            {
                mainContent.InnerHtml += @"Nie można znaleźć trasy pomiędzy wybranymi przystankami.
                                        Upewnij się, że są poprawne";//ae.Message + "</br>";

            }
        }
        protected void SaveRouteButton_Click(object sender, EventArgs e)
        {
            mainContent.InnerHtml +="O kurwa kitowcy";
        }
    }
}