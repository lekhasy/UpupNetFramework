using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Upup.Globalization;
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
            var userId = User.Identity.GetUserId();
            var isHadPo = false;
            if(userId != null)
            {
                var user = Db.Customers.Find(userId);
                var allpo = user.PurchaseOrders.Where(p => p.IsTemp).ToList();
                isHadPo = allpo.Count > 0;
            }
            
            return View(new ProductIndexViewModel {
                ProductDetail = product,
                IsHadPo = isHadPo
            });
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult CartHistory()
        {
            return View();
        }
    }

    [System.Web.Http.AllowAnonymous]
    public class ProductApiController : UpupApiControllerBase
    {
        [System.Web.Http.AllowAnonymous]
        public GetProductVariantModel GetProductVariant(string code, long quantity)
        {
            var variant = Db.ProductVariants.FirstOrDefault(p => p.VariantCode == code);
            if (variant != null)
            {
                var shipDate = variant.FindBestMatchShipDateByQuantity(quantity);
                int? shipdate = null;
                Db.Entry(variant).State = EntityState.Detached;
                if (shipDate != null)
                    shipdate = shipDate.TargetDateNumber;
                return new GetProductVariantModel
                {
                    ResultValue = true,
                    Data = variant,
                    Code = code,
                    Quantity = quantity,
                    ShipDateNumber = Convert.ToInt32(shipdate)
                };
            }
            else
            {
                return new GetProductVariantModel
                {
                    ResultValue = false,
                    Message = Lang.Product_not_exists
                };
            }
        }

        public class GetProductVariantModel : AjaxSimpleResultModel<ProductVariant>
        {
            public long Quantity { get; set; }
            public string Code { get; set; }
            public int ShipDateNumber { get; set; }
        }
    }
}