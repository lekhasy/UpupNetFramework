using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ProductCart
    {
        public long Id { get; set; }
        public long Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        public DateTime? CalculateShipDate()
        {
            var shipdate = ProductVariant.FindBestMatchShipDateByQuantity(Quantity);
            if (shipdate == null) return null;
            return DateTime.Now.AddDays(shipdate.TargetDateNumber);
        }

        public decimal CalculateTotalAmount()
        {
            return Quantity * ProductVariant.Price;
        }
    }
}