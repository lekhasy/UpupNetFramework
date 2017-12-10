using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Upup.Helpers;

namespace Upup.Web.Helpers
{
    public static class MailHelper
    {
        public static void SendMailNow(string toEmail, string subject, string htmlBody, string fromEmail, string cc, string bcc)
        {
            var beginIndex = htmlBody.IndexOf("data:image/png;base64,");
            var endIndex = htmlBody.IndexOf("\"", beginIndex);
            var stringImage64bit = htmlBody.Substring(beginIndex, endIndex - beginIndex);
            htmlBody = htmlBody.Replace(stringImage64bit, "cid:barcode");

            Byte[] bitmapData = Convert.FromBase64String(ConvertHelper.FixBase64ForImage(stringImage64bit.Substring(22)));
            MemoryStream streamBitmap = new MemoryStream(bitmapData);

            var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
            imageToInline.ContentId = "barcode";
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(imageToInline);

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
            mail.AlternateViews.Add(alternateView);
            client.Send(mail);
        }
    }
}
