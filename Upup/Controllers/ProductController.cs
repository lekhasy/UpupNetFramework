using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class ProductController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index(long? id)
        {
            var product = Db.Products.Find(id);
            return View(product);
        }

        public ActionResult Cart()
        {
            return View();
        }

       
    }

    public class ProductApiController : UpupAPIControllerBase
    {
        public GetProductVariantModel GetProductVariant(string code, int quantity)
        {
            var variant = Db.ProductVariants.FirstOrDefault(p => p.VariantCode == code);
            if (variant != null)
            {
                var shipDate = variant.ShipdateSettings.Where(s => s.QuantityOrderMax > quantity).OrderBy(s => s.QuantityOrderMax).FirstOrDefault();
                DateTime? shipdate = null;
                Db.Entry(variant).State = EntityState.Detached;
                if (shipDate != null) shipdate = DateTime.Now.AddDays(shipDate.TargetDateNumber);
                return new GetProductVariantModel
                {
                    ResultValue = true,
                    Data = variant,
                    Code = code,
                    Quantity = quantity,
                    ShipDate = shipdate
                };
            }
            else
            {
                return new GetProductVariantModel
                {
                    ResultValue = false
                };
            }
        }

        public class GetProductVariantModel : AjaxSimpleResultModel<ProductVariant>
        {
            public int Quantity { get; set; }
            public string Code { get; set; }
            public DateTime? ShipDate { get; set; }
        }
    }
}