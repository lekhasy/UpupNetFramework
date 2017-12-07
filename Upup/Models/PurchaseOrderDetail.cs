using System;

namespace Upup.Models
{
    public class PurchaseOrderDetail
    {
        public PurchaseOrderDetail()
        {

        }
        public long Id { get; set; }
        public long Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int State { get; set; }
        public decimal GetCalculatedTotalAmount() => PurchaseOrder.IsTemp ? Product.Price * Quantity : TotalAmount;
        public decimal GetCalculatedPrice() => PurchaseOrder.IsTemp ? Product.Price : Price;
        public virtual ProductVariant Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }

    public enum PoDetailState
    {
        Temp = 1,
        Ordered = 2,
        Paid = 3,
        Shipping = 4,
        Completed = 5,
    }

}