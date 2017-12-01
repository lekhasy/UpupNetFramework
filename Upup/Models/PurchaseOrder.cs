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
        public DateTime CreatedDate { get; set; }

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

    public enum PoState
    {
        Temp = 1,
        Ordered = 2,
        Paid = 3,
        Completed = 4,
        Canceled = 5
    }

}