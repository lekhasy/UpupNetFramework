using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Areas.Admin.ViewModels;
using Upup.ViewModels;

namespace Upup.Models
{
    public class PostCategory
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

        public virtual ICollection<Post> Posts { get; set; }
        public virtual PostCategory ParentCategory { get; set; }
        public virtual ICollection<PostCategory> ChildCategories { get; set; }
    }


    public enum RootPostCategory
    {
        Tech = 1,
        UserManual = 2,
        Event = 3
    }
}
