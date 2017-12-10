using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class PurchaseOrder
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalAmount => PurchaseOrderDetails.Sum(s => s.GetCalculatedTotalAmount());
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsTemp => State == (int)PoState.Temp;

        #region customer info
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerWebsite { get; set; }
        #endregion

        public PoCustomerInfoModel GetCustomerModel()
        {
            if (IsTemp)
            {
                return new PoCustomerInfoModel
                {
                    CustomerAddress = Customer.Address1,
                    CustomerEmail = Customer.Email,
                    CustomerPhone = Customer.PhoneNumber,
                    CustomerWebsite = Customer.Webiste
                };
            }
            else
            {
                return new PoCustomerInfoModel
                {
                    CustomerAddress = CustomerAddress,
                    CustomerEmail = CustomerEmail,
                    CustomerWebsite = CustomerWebsite,
                    CustomerPhone = CustomerPhone
                };
            }
        }
        public string GetPaymentMethodString()
        {
            return ((PaymentMethods)PaymentMethod).GetName();
        }

        public int CalculateCompleteShipping()
        {
            return PurchaseOrderDetails.Where(p => p.State == (int)PoDetailState.Completed).Count();
        }

        public int CalculateShipping()
        {
            return PurchaseOrderDetails.Where(p => p.State >= (int)PoDetailState.Shipping).Count();
        }

        public int CalculateTotalDetail()
        {
            return PurchaseOrderDetails.Count();
        }



        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public class PoCustomerInfoModel
    {
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerWebsite { get; set; }
    }

    public enum PoState
    {
        Temp = 1,
        Ordered = 2,
        Paid = 3,
        Completed = 4,
        Canceled = 5
    }

    public enum PaymentMethods
    {
        COD = 1,
        BankTransfer = 2
    }

    public static class PaymentMethodExtension
    {
        public static string GetName(this PaymentMethods method)
        {
            if (method == PaymentMethods.COD)
            {
                return "Thanh toán khi nhận hàng";
            }
            else
            {
                return "Chuyển khoản qua ngân hàng";
            }
        }

        private static SelectOptions GetSelectOptions(this PaymentMethods method)
        {
            var display = string.Empty;
            switch (method)
            {
                case PaymentMethods.COD: display = "Thanh toán khi nhận hàng"; break;
                case PaymentMethods.BankTransfer: display = "Chuyển khoản qua ngân hàng"; break;
                default:
                    throw new NotImplementedException($"{method} is not implemented");
            }

            return new SelectOptions((int)method, display);
        }

        public static IEnumerable<SelectOptions> GetSelectionList(bool containNotselected)
        {
            var names = Enum.GetNames(typeof(PaymentMethods));
            var options = new List<SelectOptions>(names.Length + 1);

            if (containNotselected)
                options.Add(new SelectOptions(-1, "Chọn phương thức"));

            foreach (var name in names)
            {
                Enum.TryParse(name, out PaymentMethods val);
                options.Add(GetSelectOptions(val));
            }

            return options;
        }
    }
}