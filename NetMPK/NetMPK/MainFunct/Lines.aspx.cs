using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class Lines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().userVerified)
                {
                    if (!IsPostBack)
                    {
                        DatabaseConnection db = DatabaseConnection.getInstance();
                        db.OpenConnection();
                        List<string> values = db.GetLinesNumbers();
                        db.CloseConnection();

                        foreach (string s in values)
                        {
                            mainContent.InnerHtml += "<a runat=\"server\" href=\"LineStops.aspx?linenumber=" + s + "\" class=\"btn btn-default\">" + s + "</a>";
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

        protected void lineSearchButton_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"[0-9]{2,3}");
            if (reg.IsMatch(lineSearch.Text))
            {
                Response.Redirect("LineStops.aspx?linenumber=" + lineSearch.Text);
            }
            else
            {
                ErrorMessage.Text = "Wpisz poprawny numer linii";
            }
        }
    }
}