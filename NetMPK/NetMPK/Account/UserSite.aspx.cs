using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class UserSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NetMPKGlobalVariables userInfo = NetMPKGlobalVariables.getInstance();
            if (userInfo.isUserLoggedIn)
            {
                
                if (userInfo.userVerified)
                {
                    wLabel.Text = "Witaj " + userInfo.loggedInUserName;
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