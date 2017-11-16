using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class PostCategoryController : UpupControllerBase
    {
        // GET: PostCategory
        public ActionResult Index(int id)
        {
            var current = Db.PostCategories.Find(id);
            var root = current;
            while (root.ParentCategory != null)
            {
                root = root.ParentCategory;
            }
            var vm = new PostCategoryViewModel
            {
                RootCategory = root,
                CurrentCategory = current
            };
            return View(vm);
        }
    }
}