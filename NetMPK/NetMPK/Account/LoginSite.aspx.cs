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
        private String userEmail;
        private String userPassword;
        private Boolean canRegister;
        private DatabaseConnection DBConnection;

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            bool canLogin = true;
            userLogin = Login.Text;
            userPassword = Password.Text;
            DBConnection = DatabaseConnection.getInstance();
            DBConnection.OpenConnection();
            LoginErr.Text = "";
            SuccessMessage.Text = "";

            if (DBConnection.IsUsernameInDB(userLogin)) 
            {
                LoginErr.Text = "Znaleziono uzytkownika";
                canLogin = false;
            }

            if (canLogin)
            {
                
            }
            DBConnection.CloseConnection();
        }

        
    }

}
