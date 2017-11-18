﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class PostCategoryViewModel
    {
        public List<PostCategory> RootCategories { get; set; }
        public PostCategory RootCategory { get; set; }
        public PostCategory CurrentCategory { get; set; }
    }
}