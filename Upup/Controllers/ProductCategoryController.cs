using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class ProductCategoryController : UpupControllerBase
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            ProductCategoryViewModel vm = new ProductCategoryViewModel();
            vm.Categories = Db.Categories.Where(c => c.ParentCategory == null).ToList();
            return View(vm);
        }
    }
}