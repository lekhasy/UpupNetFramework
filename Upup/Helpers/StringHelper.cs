using QRCoder;
using System;
using System.Drawing;
using System.IO;
using Upup.Globalization;
using Upup.Models;

namespace Upup.Helpers
{
    public static class StringHelper
    {
        public static string CreateQrCode(string code)
        {
            var imageUrl = string.Empty;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                return imageUrl;
            }
        }
    }
}