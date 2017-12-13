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
        public DateTime? GetCalculatedShipDate()
        {
            if (PurchaseOrder.IsTemp)
            {
                var shipdate = Product.FindBestMatchShipDateByQuantity(Quantity);
                if (shipdate == null) return null;
                return DateTime.Now.AddDays(shipdate.TargetDateNumber);
            }
            else
            {
                return ShipDate;
            }
        }
        public string GetStateString()
        {
            if (PurchaseOrder.IsTemp) return "Chưa đặt hàng";
            if (PurchaseOrder.State == (int)PoState.Ordered) return "Đợi thanh toán";
            if (PurchaseOrder.State == (int)PoState.Paid) return "Đang xử lý";
            if (State == (int)PoDetailState.InStore) return "Chuẩn bị chuyển hàng";
            if (State == (int)PoDetailState.Shipping) return "Đang chuyển hàng";
            if (State == (int)PoDetailState.Completed) return "Hoàn thành";
            return null;
        }
        public int DateShipping()
        {
            var shipdate = Product.FindBestMatchShipDateByQuantity(Quantity);
            if (shipdate == null) return 0;
            return shipdate.TargetDateNumber;
        }
        public virtual ProductVariant Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }

    public enum PoDetailState
    {
        InStore = 0,
        Shipping = 1,
        Completed = 2
    }
}