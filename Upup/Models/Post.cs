using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Title_en { get; set; }

        public string Content { get; set; }
        public string Content_en { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}