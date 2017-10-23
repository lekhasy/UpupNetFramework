using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    public class AuthCheckController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return Json("Admin");
        }

        [Authorize(Roles = "Admin, Editor")]
        public ActionResult AdminOrEditor()
        {
            return Json("Admin or editor");
        }

        [Authorize(Roles = "Admin, Customer")]
        public ActionResult AdminOrCustomer()
        {
            return Json("Admin or customer");
        }


        [Authorize(Roles = "Customer")]
        public ActionResult Customer()
        {
            return Json("customer");
        }

        [Authorize()]
        public ActionResult Authenticated()
        {
            return Json("authenticated");
        }

    }
}