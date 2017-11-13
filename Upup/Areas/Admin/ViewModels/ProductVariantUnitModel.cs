using System.Collections.Generic;

namespace Upup.Areas.Admin.ViewModels
{
    public class ProductVariantUnitModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductVariantUnitModel> AllProductVariantUnit { get; set; }
    }
}