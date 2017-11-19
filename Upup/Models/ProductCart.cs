using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class ProductCart
    {
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        [NotMapped]
        public string UnitName
        {
            get
            {
                return "";
                // return ProductVariant != null?ProductVariant
            }
        }
    }
}