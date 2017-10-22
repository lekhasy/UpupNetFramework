namespace Upup.Models
{
    public class PurchaseOrderDetail
    {
        public long Id { get; set; }
        public double Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}