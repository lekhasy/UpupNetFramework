using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class EventController : UpupControllerBase
    {
        public const string ControllerName = "Event";
        public const string InfoActionName = "EventInfo";

        public EventController()
        {

        }

        public ActionResult EventGuide()
        {
            return View(GetRootCategory());
        }

        public ActionResult EventInfo()
        {
            return View();
        }

        private PostCategory GetRootCategory()
        {
            return Db.PostCategories.First(c => c.RootCategoryIdentifier == (int)RootPostCategory.Event);
        }

    }
}