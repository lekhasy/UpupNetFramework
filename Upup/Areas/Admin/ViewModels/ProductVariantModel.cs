using System.Collections.Generic;
using Upup.Models;

namespace Upup.Areas.Admin.ViewModels
{
    public class ProductVariantModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string VariantName { get; set; }
        public string VariantCode { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public string BrandName { get; set; }
        public string Origin { get; set; }
        public int ProductVariantUnitId { get; set; }
        public string ShipDateSelected { get; set; }
    }
}