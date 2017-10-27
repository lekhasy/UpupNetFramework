using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class CategoryModel
    {
        public long Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Tên tiếng anh")]
        public string Name_en { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Mô tả tiếng anh")]
        public string Description_en { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImageUrl { get; set; }
        [Display(Name = "Danh mục cha")]
        public int ParentCategory_Id { get; set; }
        [Display(Name = "Từ khóa trang")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Mô tả trang")]
        public string MetaDescription { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }
    }
}