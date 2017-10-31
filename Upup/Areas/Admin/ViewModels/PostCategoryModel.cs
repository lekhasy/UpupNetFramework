using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class PostCategoryModel
    {
        public long Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Tên tiếng anh")]
        public string Name_en { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Mô tả tiếng anh")]
        public string Description_en { get; set; }
        [Display(Name = "Danh mục cha")]
        public int PostParentCategory_Id { get; set; }
        [Display(Name = "Từ khóa trang")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Mô tả trang")]
        public string MetaDescription { get; set; }
        [Display(Name = "Từ khóa trang tiếng anh")]
        public string MetaKeyword_en { get; set; }
        [Display(Name = "Mô tả trang tiếng anh")]
        public string MetaDescription_en { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }
    }
}