using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            try
            {
                // Initialize WebMail helper
                WebMail.SmtpServer = "mail.upup.com.vn";
                WebMail.SmtpPort = 25;
                WebMail.UserName = "no-reply@upup.com.vn";
                WebMail.Password = "Aa6LceC,<3P[3A@)";
                WebMail.From = "no-reply@upup.com.vn";
                WebMail.EnableSsl = true;

                // Create array containing file name
                //var filesList = new string[] { fileAttachment };

                // Attach file and send email
                // if there is no link to file then send email
                // without any attachment
                //if (fileAttachment == null || fileAttachment.IsEmpty())
                //{
                ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate,
                         X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
                WebMail.Send(toEmail, subject, htmlBody, fromEmail, cc, null, true, null, bcc, null, null, null, null);
                //}
                //else
                //{
                //    // otherwise, send email with file attached
                //    WebMail.Send(to: customerEmail,
                //    subject: subjectLine,
                //    body: "From: " + customerName + "\n\nHis message: " + message,
                //    filesToAttach: filesList);
                //}
            }
            catch (Exception ex)
            {
                var a = ex;
            }
        }
    }
}
