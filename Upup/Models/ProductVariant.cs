using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ProductVariant
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string VariantName { get; set; }
        public string VariantCode { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public string Cad2dUrl { get; set; }
        public string Cad3dUrl { get; set; }
        public string BrandName { get; set; }
        public string Origin { get; set; }
        public virtual ProductVariantUnit ProductVariantUnit { get; set; }
        public virtual ICollection<ShipDateSetting> ShipdateSettings { get; set; }
    }
}