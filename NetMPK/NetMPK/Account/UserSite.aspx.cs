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

                    String routeSource = Request.QueryString["firstStop"];
                    String routeEnd = Request.QueryString["lastStop"];

                    System.Diagnostics.Debug.WriteLine(routeSource);
                    System.Diagnostics.Debug.WriteLine(routeEnd);

                    if (routeSource != null && routeEnd != null)
                    {
                        db.OpenConnection();
                        int trackID = db.getTrackCount() + 1;                     
                        int userID = db.getUserID(NetMPKGlobalVariables.getInstance().loggedInUserName);

                        //db.SaveTrack(trackID, routeSource, routeEnd,userID);
                        db.CloseConnection();
                    }
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