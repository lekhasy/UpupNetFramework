using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.ViewModels;
using Upup.Web.Helpers;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class HomeController : UpupControllerBase
    {
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.Categories = Db.Categories.Where(c => c.ParentCategory == null).ToList();
            return View(vm);
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