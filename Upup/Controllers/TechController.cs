using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class TechController : UpupControllerBase
    {
        public TechController()
        {

        }

        public ActionResult TechGuide()
        {
            return View();
        }

        public ActionResult TechInfor()
        {
            return View();
        }

    }
}