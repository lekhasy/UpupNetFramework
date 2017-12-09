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
                        stateString = "Lưu tạm";
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
    }
}