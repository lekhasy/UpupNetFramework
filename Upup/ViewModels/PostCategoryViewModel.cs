using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class PostCategoryViewModel
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
}