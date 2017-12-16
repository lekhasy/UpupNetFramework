using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class PostListViewModel
    {
        
    }

    public class PostDetailViewModel
    {
        public PostCategory RootCategory { get; set; }
        public Post Post { get; set; }
        public List<Post> RelatedPosts { get; set; }
    }
}