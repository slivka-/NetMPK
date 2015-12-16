using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class LineStops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String linenumber = Request.QueryString["linenumber"];
            titleText.InnerText += linenumber;

            DatabaseConnection db = DatabaseConnection.getInstance();
            db.OpenConnection();
            List<string> values = db.GetStopsFromLine(Convert.ToInt32(linenumber));
            db.CloseConnection();

            foreach (string s in values)
            {
                mainContent.InnerHtml += "<a runat=\"server\" href=\"Timetables.aspx?linenumber=" + linenumber + "&stopname=" + s + "\" class=\"btn btn-default\">" + s + "</a>";
            }
        }
    }
}