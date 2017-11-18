using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class ProductController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index(long? id)
        {
            var product = Db.Products.Find(id);
            return View(product);
        }

        public ActionResult GetProductVariant(string code)
        {
            var variant = Db.ProductVariants.FirstOrDefault(p => p.VariantCode == code);
            if (variant != null)
            {
                return Json(new AjaxSimpleResultModel<ProductVariant>
                {
                    ResultValue = true,
                    Data = variant
                });
            }
            else
            {
                return Json(new AjaxSimpleResultModel<ProductVariant>
                {
                    ResultValue = false
                });
            }
        }
    }
}