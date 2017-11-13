using System.Collections.Generic;
using Upup.Models;

namespace Upup.Areas.Admin.ViewModels
{
    public class ShipDateSettingModel
    {
        public long Id { get; set; }
        public int QuantityOrderMax { get; set; }
        public int TargetDateNumber { get; set; }
        public List<ShipDateSettingModel> AllShipDateSetting { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}