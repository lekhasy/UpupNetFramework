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
        public string Summary { get; set; }
        public string Summary_en { get; set; }
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string LinkGuide { get; set; }
        public string Cad2dUrl { get; set; }
        public string Cad3dUrl { get; set; }

        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public string MetaKeyword_en { get; set; }
        public string MetaDescription_en { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
