using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.Account
{
    public partial class UserSite : System.Web.UI.Page
    {
        public String username;
        public String avgTime;
        public String favLine;
        private DatabaseConnection db;

        protected void Page_Load(object sender, EventArgs e)
        {
            NetMPKGlobalVariables userInfo = NetMPKGlobalVariables.getInstance();
            

            if (userInfo.isUserLoggedIn)
            {
                
                if (userInfo.userVerified)
                {
                    db = DatabaseConnection.getInstance();
                    username = userInfo.loggedInUserName;
                    db.OpenConnection();
                    List<String> stats = db.getUserStatistics(username);
                    db.CloseConnection();

                    avgTime = stats[0].Split('|')[0];
                    favLine = stats[0].Split('|')[1];
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