﻿using System;
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
        public string Description { get; set; }
        public string Description_en { get; set; }
        public string ImageUrl { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public string MetaKeyword_en { get; set; }
        public string MetaDescription_en { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
