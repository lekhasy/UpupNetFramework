using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class PostCategoryModel
    {
        public long Id { get; set; }
        public int? RootCategoryIdentifier { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }
        public string Description { get; set; }
        public string Description_en { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public string MetaKeyword_en { get; set; }
        public string MetaDescription_en { get; set; }

        public ICollection<Post> Posts { get; set; }
        public PostCategory ParentCategory { get; set; }
        public ICollection<PostCategory> ChildCategories { get; set; }
    }

    public static class PostCategoryDefault
    {
        public static List<PostCategoryModel> GetRootPostCategories()
        {
            var list = new List<PostCategoryModel>();
            var rootPostCategories = Enum.GetValues(typeof(RootPostCategory)).Cast<RootPostCategory>().ToList();
            foreach (var enu in rootPostCategories)
            {
                var idPostCategory = (long) enu;
                var namePostCategory = string.Empty;
                switch (idPostCategory)
                {
                    case 1:
                    {
                        namePostCategory = "Công nghệ";
                        break;
                    }
                    case 2:
                    {
                        namePostCategory = "Hướng dẫn sử dụng";
                        break;
                    }
                    case 3:
                    {
                        namePostCategory = "Triển lãm sự kiện";
                        break;
                    }
                }
                list.Add(new PostCategoryModel
                {
                    Id = idPostCategory,
                    Name = namePostCategory
                });
            }
            return list;
        }


    }
}