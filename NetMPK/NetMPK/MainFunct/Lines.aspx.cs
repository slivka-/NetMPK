using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class Lines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = DatabaseConnection.getInstance();
            db.OpenConnection();
            List<string> values = db.GetLinesNumbers();
            db.CloseConnection();

            foreach (string s in values)
            {
                
                mainContent.InnerHtml += "<a runat=\"server\" href=\"LineStops.aspx?linenumber="+s+"\" class=\"btn btn-default\">"+s+"</a>";
                
            }
        }
    }
}