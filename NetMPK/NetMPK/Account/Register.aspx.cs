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
    public partial class Register : Page
    {

        private String userLogin;
        private String userEmail;
        private String userPassword;
        private Boolean canRegister;
        private DatabaseConnection DBConnection;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            canRegister = true;
            userLogin = Login.Text;
            userEmail = Email.Text;
            userPassword = Password.Text;
            DBConnection = DatabaseConnection.getInstance();
            DBConnection.OpenConnection();
            LoginErr.Text = "";
            EmailErr.Text = "";
            SuccessMessage.Text = "";

            if (DBConnection.IsUsernameInDB(userLogin)) 
            {
                LoginErr.Text = "Nazwa użytkownika zajęta";
                canRegister = false;
            }
            if (DBConnection.IsMailInDB(userEmail))
            {
                EmailErr.Text = "Jest już użytkownik z takim adresem";
                canRegister = false;
            }
            if (canRegister)
            {
                Random rnd = new Random();
                int verificationCode = rnd.Next(100000, 999999);
                while (DBConnection.IsCodeInDB(verificationCode))
                {
                    verificationCode = rnd.Next(100000, 999999);
                }
                User u = new NetMPK.User();
                u.Username = userLogin;
                u.Mail = userEmail;
                u.Password = userPassword;
                u.UserStatus = 0;
                u.VerificationCode = verificationCode;
                DBConnection.SaveUser(u);
                if (sendMail(u.Mail,u.VerificationCode))
                {
                    SuccessMessage.Text = "Dziękujemy za rejestracje. Wiadomość potwierdzająca została wysłana na podany e-mail.";
                }
                else
                {
                    SuccessMessage.Text = "Dziękujemy za rejestracje.";
                    ErrorMessage.Text = "Wysłanie potwierdzenia nie powiodło się, spróbój ponownie później";
                }
            }
            DBConnection.CloseConnection();
        }

        private bool sendMail(string mailAddress, int code)
        {
            try
            { 
                MailMessage message = new MailMessage();
                message.From = new MailAddress("netmpk.mailer@gmail.com", "NetMPK");
                message.To.Add(new MailAddress(mailAddress));
                message.Subject = "Weryfikacja rejestracji";
                message.Body = "Dziękujemy za rejestracje w naszym serwisie.<br/> Twój kod aktywujący to: "+code;
                message.IsBodyHtml = true;

                NetworkCredential cred = new NetworkCredential("netmpk.mailer@gmail.com", "cde3$RFV");
                SmtpClient mailer = new SmtpClient();
                mailer.Credentials = cred;
                mailer.Host = "smtp.gmail.com";
                mailer.Port = 587;
                mailer.EnableSsl = true;
                mailer.Send(message);
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

    }

}
