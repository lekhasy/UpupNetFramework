using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ShipDateSetting
    {
        public long Id { get; set; }
        public int QuantityOrderMax { get; set; }
        public int TargetDateNumber { get; set; }
        public ICollection<ProductShipDateApply> ProductShipDateApply { get; set; }
    }
}