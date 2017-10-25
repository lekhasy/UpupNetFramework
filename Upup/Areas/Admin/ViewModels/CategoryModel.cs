using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }

        public string Descripton { get; set; }

        public string ImageUrl { get; set; }
        public int ParentCategory_Id { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }
    }
}