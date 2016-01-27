using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NetMPK.Models;
using System.Net.Mail;
using System.Net;

namespace NetMPK.Account
{
    public partial class LoginSite : Page
    {

        private String userLogin;
        private String userPassword;
        private DatabaseConnection DBConnection;

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            userLogin = Login.Text;
            userPassword = Password.Text;
            DBConnection = DatabaseConnection.getInstance();
            DBConnection.OpenConnection();
            LoginErr.Text = "";
            SuccessMessage.Text = "";

            if (DBConnection.IsUsernameInDB(userLogin))
            {
                if (DBConnection.getUsersPassword(userLogin).Equals(userPassword))
                {
                    NetMPKGlobalVariables n = NetMPKGlobalVariables.getInstance();
                    n.isUserLoggedIn = true;
                    n.loggedInUserName = userLogin;
                    int vStatus = DBConnection.getUserStatus(userLogin);
                    if (vStatus != 0)
                    {
                        n.userVerified = true;
                    }
                    
                    Response.Redirect("UserSite.aspx");
                    
                }
                else
                {
                    LoginErr.Text = "Błędne hasło!";
                }
            }
            else
            {
                LoginErr.Text = "Nie ma takiego użytkownika!";
            }

            
            DBConnection.CloseConnection();
        }

        
    }

}
