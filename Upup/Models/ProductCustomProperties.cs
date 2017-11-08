using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ProductCustomProperties
    {
        public long Id { get; set; }
        public string PropertyCode { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public string Cad2dUrl { get; set; }
        public string Cad3dUrl { get; set; }
        public virtual ICollection<ShipDateSetting> ShipDateSettings { get; set; }
    }
}