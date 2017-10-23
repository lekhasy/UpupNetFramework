using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Web.Helpers;

namespace Upup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //MailHelper.SendMailNow("thangphuong88@gmail.com", "Test", "Test hàng cái nha", null, null, null);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}