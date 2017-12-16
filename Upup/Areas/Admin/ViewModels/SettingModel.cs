using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Upup.Areas.Admin.ViewModels
{
    public class SettingModel
    {
        [Display(Name = "Logo Website")]
        public string LogoUrl { get; set; }
        [Display(Name = "Đường dẫn Facebook")]
        public string FacebookLink { get; set; }
        [Display(Name = "Đường dẫn Google Plus")]
        public string GooglePlus { get; set; }
        [Display(Name = "Đường dẫn Twitter")]
        public string Twitter { get; set; }
        [Display(Name = "Đường dẫn Youtube")]
        public string YoutubeLink { get; set; }
        [Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Số fax")]
        public string Fax { get; set; }
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }
        [Display(Name = "Thời gian làm việc")]
        [AllowHtml]
        public string WorkTime { get; set; }
        [Display(Name = "Biểu ngữ")]
        [AllowHtml]
        public string Slogan { get; set; }
        [Display(Name = "Biểu ngữ tiếng anh")]
        [AllowHtml]
        public string Slogan_en { get; set; }
        [Display(Name = "Từ khóa website")]
        public string MetaKeyword { get; set; }
        [Display(Name = "Từ khóa tiếng anh website")]
        public string MetaKeyword_en { get; set; }
        [Display(Name = "Mô tả website")]
        public string MetaDescription { get; set; }
        [Display(Name = "Mô tả tiếng anh website")]
        public string MetaDescription_en { get; set; }
        [Display(Name = "Banner trang công nghệ")]
        public string TechBannerUrl { get; set; }
        [Display(Name = "Biểu ngữ trang công nghệ")]
        [AllowHtml]
        public string TechSlogan { get; set; }
        [Display(Name = "Banner trang hướng dẫn")]
        public string GuideBannerUrl { get; set; }
        [Display(Name = "Biểu ngữ trang hướng dẫn")]
        [AllowHtml]
        public string GuideSlogan { get; set; }
        [Display(Name = "Banner trang sự kiện")]
        public string EventBannerUrl { get; set; }
        [Display(Name = "Biểu ngữ trang sự kiện")]
        [AllowHtml]
        public string EventSlogan { get; set; }
        [Display(Name = "Banner 1 trang chủ")]
        public string MainBannerUrl1 { get; set; }
        [Display(Name = "Biểu ngữ 1 trang chủ")]
        [AllowHtml]
        public string MainSlogan1 { get; set; }
        [Display(Name = "Banner 2 trang chủ")]
        public string MainBannerUrl2 { get; set; }
        [Display(Name = "Biểu ngữ 2 trang chủ")]
        [AllowHtml]
        public string MainSlogan2 { get; set; }
        [Display(Name = "Banner 3 trang chủ")]
        public string MainBannerUrl3 { get; set; }
        [Display(Name = "Biểu ngữ 3 trang chủ")]
        [AllowHtml]
        public string MainSlogan3 { get; set; }
        [Display(Name = "Banner 4 trang chủ")]
        public string MainBannerUrl4 { get; set; }
        [Display(Name = "Biểu ngữ 4 trang chủ")]
        [AllowHtml]
        public string MainSlogan4 { get; set; }
    }
}