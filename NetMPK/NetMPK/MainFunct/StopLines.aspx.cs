﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class StopLines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String stopname = Request.QueryString["stopname"];
            titleText.InnerText += stopname;

            DatabaseConnection db = DatabaseConnection.getInstance();
            db.OpenConnection();
            List<string> values = db.GetLinesFromStop(stopname);
            db.CloseConnection();

            foreach (string s in values)
            {
                mainContent.InnerHtml += "<a runat=\"server\" href=\"Timetables.aspx?linenumber=" + s + "&stopname="+stopname+"\" class=\"btn btn-default\">" + s + "</a>";
            }
        }
    }
}