using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NetMPK.MainFunct
{
    public partial class Timetables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = DatabaseConnection.getInstance();
            db.OpenConnection();
            List<string> values = db.GetLinesNumbers();
            db.CloseConnection();
            int index = 0;
            foreach (string s in values)
            {
                HtmlGenericControl newControl = new HtmlGenericControl("div");
                newControl.ID = s + index++;
                newControl.InnerHtml = @"<a runat=""server"" href=""~/MainFunc"" class=""btn btn-default"">" + s;
                divTime.Controls.Add(newControl);
            }
        }
    }
}