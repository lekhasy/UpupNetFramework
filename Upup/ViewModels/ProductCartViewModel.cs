using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class ProductCartItemModel
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductVariantCode { get; set; }
        public int Quantity { get; set; }
        public string UnitName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}