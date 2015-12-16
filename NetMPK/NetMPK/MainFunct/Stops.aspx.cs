using System;
using System.Collections.Generic;
using System.Linq;
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
            DBConn = DatabaseConnection.getInstance();
            DBConn.OpenConnection();
            List<String> StopsList = DBConn.GetLinesStopNames();
            DBConn.CloseConnection();
            foreach (String StopName in StopsList)
            {
                mainContent.InnerHtml += " <a runat=\"server\" href=\"~/MainFunct/Timetables\" class = \"btn btn-default\">" + StopName + "</a>";
            }
            
        }
    }
}