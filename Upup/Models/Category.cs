using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }

        public string Descripton { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}