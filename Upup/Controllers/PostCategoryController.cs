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
            var vm = new PostCategoryViewModel
            {
                PostCategories = Db.PostCategories.Where(c => c.ParentCategory == null).ToList()
            };
            return View(vm);
        }
    }
}