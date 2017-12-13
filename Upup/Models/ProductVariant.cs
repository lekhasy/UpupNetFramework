using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ProductVariant
    {
        public long Id { get; set; }
        public string VariantName { get; set; }
        public string VariantCode { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public decimal Reserved { get; set; }
        public string BrandName { get; set; }
        public string Origin { get; set; }
        public string Cad2dUrl { get; set; }
        public string Cad3dUrl { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductVariantUnit ProductVariantUnit { get; set; }
        public virtual ICollection<ShipDateSetting> ShipdateSettings { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }


        public ShipDateSetting FindBestMatchShipDateByQuantity(long quantity)
        {
            var RealOnHand = OnHand;
            // [TODO] need perfomance improvement
            var allreserved = PurchaseOrderDetails.Where(p => p.PurchaseOrder.State == (int)PoState.Paid);
            if (allreserved.Any())
            {
                RealOnHand = OnHand - allreserved.Sum(r => r.Quantity);
            }
            if (RealOnHand >= quantity)
            {
                // only need 1 day to ready for shipping
                return new ShipDateSetting { Id = -1, TargetDateNumber = 1};
            }
            else
            {
                var missingQuantity = quantity - RealOnHand;
                return ShipdateSettings.Where(s => s.QuantityOrderMax > missingQuantity).OrderBy(s => s.QuantityOrderMax).FirstOrDefault();
            }
        }
    }
}