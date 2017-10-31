using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }
        public int Category_Id { get; set; }
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword_en { get; set; }
        public string MetaDescription_en { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}