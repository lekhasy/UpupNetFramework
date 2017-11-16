using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class UserManualController : UpupControllerBase
    {
        public const string ControllerName = "UserManual";
        public const string InfoActionName = "ManualInfo";
        
        public ActionResult ManualGuide()
        {
            ViewBag.ControllerName = ControllerName;

            return View(GetRootCategory());
        }

        public ActionResult Category(int id)
        {
            var current = Db.PostCategories.Find(id);
            var vm = new PostCategoryViewModel
            {
                RootCategory = GetRootCategory(),
                CurrentCategory = current
            };
            ViewBag.ControllerName = ControllerName;

            return View("_PostCategoryPartial", vm);
        }

        public ActionResult ManualInfo(long id)
        {
            var post = Db.Posts.Find(id);

            var vm = new PostDetailViewModel
            {
                Post = post,
                RootCategory = GetRootCategory()
            };
            ViewBag.ControllerName = ControllerName;

            return View(vm);
        }
        private PostCategory GetRootCategory()
        {
            return Db.PostCategories.First(c => c.RootCategoryIdentifier == (int)RootPostCategory.UserManual);
        }


    }
}