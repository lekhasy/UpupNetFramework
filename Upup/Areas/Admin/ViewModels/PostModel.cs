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
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề tiếng anh")]
        public string Title_en { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Nội dung tiếng anh")]
        public string Content_en { get; set; }
        [Display(Name = "Danh mục bài viết")]
        public int Category_id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Từ khóa trang")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Mô tả trang")]
        public string MetaDescription { get; set; }
        [Display(Name = "Từ khóa trang tiếng anh")]
        public string MetaKeyword_en { get; set; }
        [Display(Name = "Mô tả trang tiếng anh")]
        public string MetaDescription_en { get; set; }
        public List<SelectListItem> PostCategories { get; set; }
    }
}