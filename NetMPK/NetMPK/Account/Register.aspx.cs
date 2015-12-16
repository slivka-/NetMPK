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

        protected void CreateUser_Click(object sender, EventArgs e)
        {
           // sendMail(Email.Text);
        }

        /*
        private Boolean sendMail(string mailAdress)
        {
            
            try
            {
                //string fileName = HttpContext.Current.Server.MapPath("kod.txt");
                string serverSMTP = "poczta.interia.pl";
                int portSMTP = 587;
                SmtpClient smtp = new SmtpClient(serverSMTP, portSMTP);
                string adres = "miho6@interia.pl";
                smtp.Credentials = new NetworkCredential(adres, "T696270141$%");
                MailMessage mail = new MailMessage(adres, mailAdress);
                mail.Subject = "TEST";
                mail.Body = "TESTTTTTTT";
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