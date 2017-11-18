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
    public class TechController : UpupControllerBase
    {
        public const string ControllerName = "Tech";
        public const string TechInfoActionName = "TechInfo";

        public TechController()
        {

        }

        public ActionResult Category(int id)
        {
            var allPostCategories = Db.PostCategories;
            var current = allPostCategories.Find(id);
            var rootCategories = allPostCategories.Where(cat => cat.RootCategoryIdentifier > 0 ).ToList();
            var vm = new PostCategoryViewModel
            {
                RootCategories = rootCategories,
                RootCategory = GetRootCategory(),
                CurrentCategory = current
            };
            ViewBag.ControllerName = ControllerName;

            return View("_PostCategoryPartial", vm);
        }

        public ActionResult TechGuide()
        {
            var rootCategories = Db.PostCategories.Where(cat => cat.RootCategoryIdentifier > 0).ToList();
            ViewBag.ControllerName = ControllerName;

            return View(new TechGuideModel {
                RootCategory = GetRootCategory(),
                RootCategories = rootCategories
            });
        }

        public ActionResult TechInfo(long id)
        {
            var post = Db.Posts.Find(id);
            var rootCategories = Db.PostCategories.Where(cat => cat.RootCategoryIdentifier > 0).ToList();

            var vm = new PostDetailViewModel
            {
                Post = post,
                RootCategory = GetRootCategory(),
                RootCategories = rootCategories
            };
            ViewBag.ControllerName = ControllerName;

            return View(vm);
        }

        private PostCategory GetRootCategory()
        {
            return Db.PostCategories.First(c => c.RootCategoryIdentifier == (int)RootPostCategory.Tech);
        }

    }
}