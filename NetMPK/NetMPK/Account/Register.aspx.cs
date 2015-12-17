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

        protected void CreateUser_Click(object sender, EventArgs e)
        {
           // sendMail(Email.Text);
        }

        /*
        private Boolean sendMail(string mailAdress)
        {
            
            try
            {
                
                string serverSMTP = "";
                int portSMTP = 587;
                SmtpClient smtp = new SmtpClient(serverSMTP, portSMTP);
                string adres = "";
                smtp.Credentials = new NetworkCredential(adres, "");
                MailMessage mail = new MailMessage(adres, mailAdress);
                mail.Subject = "TEST";
                mail.Body = "TEST";
                mail.IsBodyHtml = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
        */
    }

}
