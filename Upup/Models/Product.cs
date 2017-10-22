using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
        public string Name_en { get; set; }

        public decimal Price { get; set; }

        public decimal OnHand { get; set; }

        public virtual Category Categories { get; set; }
    }
}