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
                    List<String> tracks = db.getUserTracks(username);
                    db.CloseConnection();

                    avgTime = stats[0].Split('|')[0];
                    favLine = stats[0].Split('|')[1];

                    String routeSource = Request.QueryString["firstStop"];
                    String routeEnd = Request.QueryString["lastStop"];
                    int cnt = 1;
                    db.OpenConnection();

                    foreach (String s in tracks)
                    {
                        int startID = int.Parse(s.Split('|')[0]);
                        int endID = int.Parse(s.Split('|')[1]);

                        String startName = db.GetStopNameFromID(startID);
                        String endName = db.GetStopNameFromID(endID);

                        savedTracks.InnerHtml += "Trasa " + cnt + ") " + startName + " -> " + endName;
                        savedTracks.InnerHtml += " <a runat=\"server\" href=\"http://localhost:54369/MainFunct/Routes.aspx?firstStop="+startName+"&lastStop="+endName+"\" class = \"btn btn-default\">Przejdz</a></br>";

                        cnt++;
                    }
                    db.CloseConnection();
                    if (routeSource != null && routeEnd != null)
                    {
                        db.OpenConnection();
                        int trackID = db.getTrackCount() + 1;                     
                        int userID = db.getUserID(NetMPKGlobalVariables.getInstance().loggedInUserName);

                        db.SaveTrack(trackID, routeSource, routeEnd,userID);
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