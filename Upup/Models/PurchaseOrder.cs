using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Globalization;

namespace Upup.Models
{
    public class PurchaseOrder
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalMoney => PurchaseOrderDetails.Sum(s => s.GetCalculatedTotalMoney());
        public decimal TotalAmount => TotalMoney + ((TotalMoney * 10)/100);
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string QuotationCode { get; set; }

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

        public string GetStateString()
        {
            return ((PoState)State).GetName();
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
        Shipped = 4,
        Completed = 5,
        Canceled = 6
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
                return Lang.Pay_Meth_COD;
            }
            else
            {
                return Lang.Pay_Meth_Transfer;
            }
        }

        private static SelectOptions GetSelectOptions(this PaymentMethods method)
        {
            return new SelectOptions((int)method, method.GetName());
        }

        public static IEnumerable<SelectOptions> GetSelectionList(bool containNotselected)
        {
            var names = Enum.GetNames(typeof(PaymentMethods));
            var options = new List<SelectOptions>(names.Length + 1);

            if (containNotselected)
                options.Add(new SelectOptions(-1, Lang.Undetermine));

            foreach (var name in names)
            {
                Enum.TryParse(name, out PaymentMethods val);
                options.Add(GetSelectOptions(val));
            }

            return options;
        }
    }

    public static class POStateExtension
    {
        public static string GetName(this PoState state)
        {
            switch (state)
            {
                case PoState.Ordered: return Lang.Ordered;
                case PoState.Paid: return Lang.Paid;
                case PoState.Shipped: return Lang.Shipping;
                case PoState.Completed: return Lang.Completed;
                case PoState.Canceled: return Lang.Canceled;
                case PoState.Temp: return Lang.TempPO;
                default: return string.Empty;
            }
        }
    }
}