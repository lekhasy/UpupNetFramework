using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class PostCategoryViewModel
    {
        public PostCategory RootCategory { get; set; }
        public PostCategory CurrentCategory { get; set; }
    }
}