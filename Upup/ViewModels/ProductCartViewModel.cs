using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class ProductCartItem
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public long ProductVariantId { get; set; }
        public string ProductVariantCode { get; set; }
        public int Quantity { get; set; }
        public string Etc { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}