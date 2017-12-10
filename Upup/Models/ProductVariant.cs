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
        public virtual Product Product { get; set; }
        public virtual ProductVariantUnit ProductVariantUnit { get; set; }
        public virtual ICollection<ShipDateSetting> ShipdateSettings { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }

        public ShipDateSetting FindBestMatchShipDateByQuantity(long quantity)
        {
            return ShipdateSettings.Where(s => s.QuantityOrderMax > quantity).OrderBy(s => s.QuantityOrderMax).FirstOrDefault();
        }
    }
}