using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }
        public string Description { get; set; }
        public string Description_en { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public string MetaKeyword_en { get; set; }
        public string MetaDescription_en { get; set; }

        public virtual ICollection<CategoryModel> ChildCategories { get; set; }
    }
}