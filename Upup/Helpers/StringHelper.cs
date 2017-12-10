using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace Upup.Helpers
{
    public static class StringHelper
    {
        public static string GetPoStateByCode(int code) {
            var stateString = string.Empty;
            switch (code)
            {
                case 2:
                    {
                        stateString = "Đã đặt hàng";
                        break;
                    }
                case 3:
                    {
                        stateString = "Đã thanh toán";
                        break;
                    }
                case 4:
                    {
                        stateString = "Vận chuyển";
                        break;
                    }
                case 5:
                    {
                        stateString = "Đã hoàn thành";
                        break;
                    }
                case 6:
                    {
                        stateString = "Đã hủy";
                        break;
                    }
                default:
                    {
                        stateString = "Đơn hàng tạm";
                        break;
                    }
            }
            return stateString;
        }

        public static string GetPoPaymentMethodByCode(int code)
        {
            var stateString = string.Empty;
            switch (code)
            {
                case 1:
                    {
                        stateString = "Chuyển khoản qua ngân hàng";
                        break;
                    }
                case 2:
                    {
                        stateString = "Thanh toán tiền mặt khi nhận hàng";
                        break;
                    }
                default:
                    {
                        stateString = "Chưa xác định";
                        break;
                    }
            }
            return stateString;
        }

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