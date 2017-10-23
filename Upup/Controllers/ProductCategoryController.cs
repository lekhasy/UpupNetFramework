using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    public class ProductCategoryController : ControllerBase
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}