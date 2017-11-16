using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class UserManualController : UpupControllerBase
    {
        public const string ControllerName = "UserManual";
        public const string InfoActionName = "ManualInfo";
        
        public ActionResult ManualGuide()
        {
            return View();
        }

        public ActionResult ManualInfo()
        {
            return View();
        }

    }
}