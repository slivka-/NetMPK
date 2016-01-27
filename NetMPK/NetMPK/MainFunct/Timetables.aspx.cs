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
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                //TU KOD STRONY
            }
            else
            {
                Response.Redirect("NotLoggedIn");
            }
        }
    }
}