using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.Account
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        public String adminName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().admin)
                {
                    adminName = NetMPKGlobalVariables.getInstance().loggedInUserName;
                    //KOD
                }
                else
                {
                    Response.Redirect("~/Account/LogoutSite.aspx");
                }
            }
            else
            {
                Response.Redirect("~/MainFunct/NotLoggedIn.aspx");
            }
        }
    }
}