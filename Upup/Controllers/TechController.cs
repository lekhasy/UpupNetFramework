﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class TechController : UpupControllerBase
    {
        public const string ControllerName = "Tech";
        public const string TechInfoActionName = "TechInfo";

        public TechController()
        {

        }

        public ActionResult TechGuide()
        {
            return View(GetRootCategory());
        }

        public ActionResult TechInfo(long id)
        {
            var post = Db.Posts.Find(id);

            var vm = new PostDetailViewModel
            {
                Post = post,
                RootCategory = GetRootCategory()
            };
            return View(vm);
        }

        private PostCategory GetRootCategory()
        {
            return Db.PostCategories.First(c => c.RootCategoryIdentifier == (int)RootPostCategory.Tech);
        }

    }
}