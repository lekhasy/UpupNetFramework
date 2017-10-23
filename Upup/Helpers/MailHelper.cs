using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Upup.Web.Helpers
{
    public static class MailHelper
    {
        public static void SendMailNow(string toEmail, string subject, string htmlBody, string fromEmail, string cc, string bcc)
        {
            MailMessage mail = new MailMessage("no-reply@upup.com.vn", toEmail);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.upup.com.vn";
            client.Credentials = new NetworkCredential("no-reply@upup.com.vn", "Aa6LceC,<3P[3A@)");
            mail.Subject = subject;
            mail.Body = htmlBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
    }
}
