using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    public class AuthCheckController : UpupControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return Json("Admin", JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin, Editor")]
        public ActionResult AdminOrEditor()
        {
            return Json("Admin or editor", JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin, Customer")]
        public ActionResult AdminOrCustomer()
        {
            return Json("Admin or customer", JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Customer")]
        public ActionResult Customer()
        {
            return Json("customer", JsonRequestBehavior.AllowGet);
        }

        [Authorize()]
        public ActionResult Authenticated()
        {
            return Json("authenticated", JsonRequestBehavior.AllowGet);
        }

    }
}