using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class PoItemModel
    {
        public string Code { get; internal set; }
        public long Id { get; internal set; }
        public string Name { get; internal set; }
        public int State { get; internal set; }
        public int Sequence { get; internal set; }
        public string ShipingProgress { get; internal set; }
        public string CompleteProgress { get; internal set; }
        public bool Ordered { get; internal set; }
        public bool Paid { get; internal set; }
        public bool Removable => Paid ? false : true;
        public DateTime CreatedDate { get; set; }
    }

    public class PoDetailItemModel
    {
        public long Id { get; set; }
        public int Sequence { get; set; }
        public string ProductCode { get; set; }
        public string ProductVariantCode { get; set; }
        public long Quantity { get; set; }
        public string UnitName { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ProductVariantName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string StateString { get; set; }
    }

}