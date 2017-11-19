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

        public IEnumerable<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ApplicationUser Customer { get; set; }
    }
}