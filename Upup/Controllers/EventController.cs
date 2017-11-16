using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult EventInfo()
        {
            return View();
        }

    }
}