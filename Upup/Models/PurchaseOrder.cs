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
        public string CustomerName { get; set; }
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
                    CustomerName = Customer.FullName,
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
                    CustomerName = CustomerName,
                    CustomerPhone = CustomerPhone
                };
            }
        }

        public int CalculateCompleteShipping()
        {
            return PurchaseOrderDetails.Where(p => p.State == (int)PoDetailState.Completed || p.State == (int)PoDetailState.Canceled).Count();
        }

        public int CalculateShipping()
        {
            return PurchaseOrderDetails.Where(p => p.State == (int)PoDetailState.Shipping).Count();
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
        public string CustomerName { get; set; }
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

}