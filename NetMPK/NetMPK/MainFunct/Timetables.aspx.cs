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
    }
}