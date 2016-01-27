using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class Stops : System.Web.UI.Page
    {
        private DatabaseConnection DBConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().userVerified)
                {
                    if (!IsPostBack)
                    {
                        DBConn = DatabaseConnection.getInstance();
                        DBConn.OpenConnection();
                        List<String> StopsList = DBConn.GetLinesStopNames();
                        DBConn.CloseConnection();
                        foreach (String StopName in StopsList)
                        {
                            mainContent.InnerHtml += " <a runat=\"server\" href=\"StopLines.aspx?stopname=" + StopName + "\" class = \"btn btn-default\">" + StopName + "</a></br></br>";
                        }
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

        protected void stopSearchButton_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"[^0-9\:\;\'\{\}\[\]\<\>\?\/\\\+\=\)\(\*\&\^\%\$\#\@\!\~\`]+");
            if (reg.IsMatch(stopSearch.Text))
            {
                Response.Redirect("StopLines.aspx?stopname=" + stopSearch.Text);
            }
            else
            {
                ErrorMessage.Text = "Wpisz poprawną nazwe przystanku";
            }
        }
    }
}