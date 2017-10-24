using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class PostCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_en { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual PostCategory ParentCategory { get; set; }
        public virtual ICollection<PostCategory> ChildCategories { get; set; }
    }
}
