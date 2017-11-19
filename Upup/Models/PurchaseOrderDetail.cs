using System;

namespace Upup.Models
{
    public class PurchaseOrderDetail
    {
        public long Id { get; set; }
        public double Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public int State { get; set; }
        public virtual ProductVariant Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}