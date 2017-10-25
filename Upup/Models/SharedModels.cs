using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Upup.Models {
    public class MetaModel {
        public string Title { get; set; }
        public string Keywork { get; set; }
        public string Description { get; set; }
    }

    public class RoleModel {
        public int Id { get; set; }

        [Display(Name = "Tên vai trò")]
        public string RoleName { get; set; }
    }

    public class ImagesViewModel {
        public string Url { get; set; }
    }

    public class BannerModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Tên banner")]
        public string BannerName { get; set; }

        [Display(Name = "Hình ảnh")]
        public string BannerImageUrl { get; set; }

        [Display(Name = "Đường dẫn trang")]
        public string BannerLink { get; set; }
    }

    public class AuthorModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Tên tác giả")]
        public string AuthorName { get; set; }
        public string AvatarUrl { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class PublisherModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Tên nhà xuất bản")]
        public string PublisherName { get; set; }
        public string LogoUrl { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Nhà phát hành")]
        public bool IsExporter { get; set; }
    }

    public class ContactModel {
        public int Id { get; set; }

        public string IpAddress { get; set; }

        [Required(ErrorMessage = "Họ Tên vui lòng không để trống")]
        [Display(Name = "Tên của bạn")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email vui lòng không để trống")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RegularExpression(@"/^[1-9]$|^0[1-9]$|^1[0-9]$|^13$/",
                            ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Vui lòng chọn chủ đề")]
        [Display(Name = "Chủ đề")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nội dung vui lòng không để trống")]
        [Display(Name = "Nội dung")]
        public string Contents { get; set; }
        public int BookId { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class NewsModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Dành cho bài dự thi")]
        public bool ForCompose { get; set; }

        //[Required(ErrorMessage = "Tiêu đề vui lòng không để trống")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Mô tả vui lòng không để trống")]
        [Display(Name = "Mô tả ngắn")]
        public string Summary { get; set; }
        public int CommentCount { get; set; }

        //[Required(ErrorMessage = "Nội dung vui lòng không để trống")]
        [Display(Name = "Nội dung")]
        public string Details { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        public string CreatedOnJson { get; set; }

        [Display(Name = "Mô tả trang")]
        //[Required(ErrorMessage = "Vui lòng điền mô tả trang")]
        public string PageDescription { get; set; }

        [Display(Name = "Từ khóa trang")]
        //[Required(ErrorMessage = "Vui lòng điền từ khóa trang")]
        public string PageKeywords { get; set; }
    }

    public class BookCategoryModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Danh mục cha")]
        public int ParentId { get; set; }

        //[Required(ErrorMessage = "Tên danh mục vui lòng không để trống")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Hình đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Danh mục tuyển tập")]
        public bool IsCollection { get; set; }

        [Display(Name = "Nổi bật")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Không hiển thị")]
        public bool Offline { get; set; }

        [Display(Name = "Mô tả trang")]
        //[Required(ErrorMessage = "Vui lòng điền mô tả trang")]
        public string PageDescription { get; set; }

        [Display(Name = "Từ khóa trang")]
        //[Required(ErrorMessage = "Vui lòng điền từ khóa trang")]
        public string PageKeywords { get; set; }
        public int BookCount { get; set; }
        public List<SelectListItem> ParentCategories { get; set; }
        public List<BookCategoryModel> SubCategories { get; set; }
    }

    public class BookModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Vui lòng chọn danh mục cho sách")]
        [Display(Name = "Chọn danh mục")]
        public int IdCategory { get; set; }

        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }

        //[Required(ErrorMessage = "Vui lòng điền tên sách")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Vui lòng chọn hình sách")]
        [Display(Name = "Hình sách")]
        public string ImageUrl { get; set; }

        //[Required(ErrorMessage = "Vui lòng điền tác giả")]
        [Display(Name = "Tác giả")]
        public int IdAuthor { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int IdPublisher { get; set; }
        [Display(Name = "Nhà phát hành")]
        public int IdExporter { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string ExporterName { get; set; }

        //[Required(ErrorMessage = "Vui lòng viết vài dòng tóm lượt")]
        [Display(Name = "Tóm lượt")]
        public string Summary { get; set; }

        [Display(Name = "Đính kèm file")]
        public string FileUrl { get; set; }

        [Display(Name = "Sách miễn phí")]
        public bool IsFree { get; set; }

        //[Required(ErrorMessage = "Vui lòng điền giá sách")]
        [Display(Name = "Giá")]
        public Decimal Price { get; set; }

        [Display(Name = "Điểm đánh giá")]
        public int RatingScore { get; set; }

        [Display(Name = "Lượt xem")]
        public int ViewCount { get; set; }

        [Display(Name = "Sách đặc sắc")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Mô tả trang")]
        //[Required(ErrorMessage = "Vui lòng điền mô tả trang")]
        public string PageDescription { get; set; }

        [Display(Name = "Từ khóa trang")]
        //[Required(ErrorMessage = "Vui lòng điền từ khóa trang")]
        public string PageKeywords { get; set; }

        [Display(Name = "Thẻ Tag")]
        //[Required(ErrorMessage = "Vui lòng thêm thẻ Tag")]
        public string Tags { get; set; }

        public bool IsBookmarked { get; set; }

        public List<SelectListItem> BookAuthors { get; set; }
        public List<SelectListItem> BookPublishers { get; set; }
        public List<SelectListItem> BookExporters { get; set; }
        public List<SelectListItem> BookCategories { get; set; }
        public List<SelectListItem> TagCategories { get; set; } 
    }

    public class PartnerModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Tên đối tác vui lòng không để trống")]
        [Display(Name = "Tên đối tác")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Nhãn hiển thị vui lòng không để trống")]
        [Display(Name = "Nhãn hiển thị")]
        public string ShowingLabel { get; set; }

        //[Required(ErrorMessage = "Đường dẫn trang vui lòng không để trống")]
        [Display(Name = "Đường dẫn trang")]
        public string Link { get; set; }
    }

    public class TagModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Tên thẻ vui lòng không để trống")]
        [Display(Name = "Tên thẻ")]
        public string TagName { get; set; }
    }

    public class ComposeSubjectsModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Tên chủ đề vui lòng không để trống")]
        [Display(Name = "Tên chủ đề")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Mô tả vui lòng không để trống")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Hiển thị trên Menu")]
        public bool ShowOnMenu { get; set; }
    }

    public class PolicyModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        [Display(Name = "Tên chủ đề")]
        public string Name { get; set; }

        [Display(Name = "Nội dung")]
        public string Detail { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsEnabled { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class ComposeModel {
        [Display(Name = "Số ID")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Vui lòng điền tên bài dự thi")]
        [Display(Name = "Tên bài dự thi")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Vui lòng điền tên tác giả")]
        [Display(Name = "Tên tác giả")]
        public string Author { get; set; }

        //[Required(ErrorMessage = "Vui lòng chọn hình đại diện")]
        [Display(Name = "Hình đại diện")]
        public string ImageUrl { get; set; }

        //[Required(ErrorMessage = "Vui lòng không để trống nội dung")]
        [Display(Name = "Nội dung")]
        public string Details { get; set; }

        [Display(Name = "Lượt bình luận")]
        public int CommentCount { get; set; }

        [Display(Name = "Mô tả trang")]
        //[Required(ErrorMessage = "Vui lòng điền mô tả trang")]
        public string PageDescription { get; set; }

        [Display(Name = "Từ khóa trang")]
        //[Required(ErrorMessage = "Vui lòng điền từ khóa trang")]
        public string PageKeywords { get; set; }

        //[Required(ErrorMessage = "Vui lòng chọn chủ đề cho bài viết")]
        [Display(Name = "Chọn chủ đề")]
        public string Subjects { get; set; }
        public List<SelectListItem> ComposeSubjects { get; set; }
    }
}