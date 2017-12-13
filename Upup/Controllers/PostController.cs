using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class PostController : UpupControllerBase
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            var post = Db.Posts.Find(id);
            var rootCategory = post.Category;
            if (rootCategory != null)
            {
                while (rootCategory.RootCategoryIdentifier == null)
                {
                    rootCategory = rootCategory.ParentCategory;
                }
                if (rootCategory.RootCategoryIdentifier == (int)RootPostCategory.Tech)
                {
                    return RedirectToAction(TechController.TechInfoActionName, TechController.ControllerName, new { id = id });
                }
                else if (rootCategory.RootCategoryIdentifier == (int)RootPostCategory.UserManual)
                {
                    return RedirectToAction(UserManualController.InfoActionName, UserManualController.ControllerName, new { id = id });
                }
                else if (rootCategory.RootCategoryIdentifier == (int)RootPostCategory.Event)
                {
                    return RedirectToAction(EventController.InfoActionName, EventController.ControllerName, new { id = id });
                }
            }
            return RedirectToRoute("Default");

        }
    }
}