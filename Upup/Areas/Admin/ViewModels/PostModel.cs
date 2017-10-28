using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class PostModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Title_en { get; set; }

        public string Content { get; set; }
        public string Content_en { get; set; }
        public int Category_id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Từ khóa trang")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Mô tả trang")]
        public string MetaDescription { get; set; }
        public List<SelectListItem> PostCategories { get; set; }
    }
}