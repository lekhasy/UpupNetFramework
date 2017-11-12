using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class ProductModel
    {
        public long Id { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Tên sản phẩm tiếng anh")]
        public string Name_en { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string Summary { get; set; }
        [Display(Name = "Mô tả ngắn tiếng anh")]
        public string Summary_en { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        public int Category_Id { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImageUrl { get; set; }
        [Display(Name = "File Pdf đính kèm")]
        public string PdfUrl { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public decimal Price { get; set; }
        [Display(Name = "Số lượng tồn kho")]
        public decimal OnHand { get; set; }
        [Display(Name = "Từ khóa trang")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Mô tả trang")]
        public string MetaDescription { get; set; }
        [Display(Name = "Từ khóa trang tiếng anh")]
        public string MetaKeyword_en { get; set; }
        [Display(Name = "Mô tả trang tiếng anh")]
        public string MetaDescription_en { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> ProductVariantUnits { get; set; }
        public List<SelectListItem> ShipdateSettings { get; set; }
        public List<ProductVariantModel> Variants { get; set; }
    }
}