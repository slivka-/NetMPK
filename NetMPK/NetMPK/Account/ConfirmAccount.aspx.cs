using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class ConfirmAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                //KOD STRONY
            }
            else
            {
                Response.Redirect("~/MainFunct/NotLoggedIn.aspx");
            }
        }

        protected void ConfirmUser_Click(object sender, EventArgs e)
        {
            String code = vCode.Text;
            Regex r = new Regex("[0-9]{6}");
            if (r.IsMatch(code))
            {
                DatabaseConnection db = DatabaseConnection.getInstance();
                NetMPKGlobalVariables userInfo = NetMPKGlobalVariables.getInstance();
                int codeInt = int.Parse(code);
                int userCode = db.getUserVerificationCode(userInfo.loggedInUserName);
                if (userCode == codeInt)
                {
                    userInfo.userVerified = true;
                    db.confirmUser(userInfo.loggedInUserName);
                    Response.Redirect("~/Account/UserSite.aspx");
                }
                else
                {
                    codeErr.Text = "Błędny kod";
                }
            }
            else
            {
                codeErr.Text = "Niepoprawny format kodu";
            }
        }

        protected void ResendEmail(object sender, EventArgs e)
        {
            DatabaseConnection db = DatabaseConnection.getInstance();
            String userName = NetMPKGlobalVariables.getInstance().loggedInUserName;
            String email = db.getUserEmail(userName);
            int code = db.getUserVerificationCode(userName);
            if (sendMail(email, code))
            {
                resendLabelSuccess.Text = "Wysłano ponownie";
            }
            else
            {
                resendLabelErr.Text = "Błąd! Spróbuj ponownie później";
            }
        }

        private bool sendMail(string mailAddress, int code)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("netmpk.mailer@gmail.com", "NetMPK");
                message.To.Add(new MailAddress(mailAddress));
                message.Subject = "Weryfikacja rejestracji";
                message.Body = "Dziękujemy za rejestracje w naszym serwisie.<br/> Twój kod aktywujący to: " + code;
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