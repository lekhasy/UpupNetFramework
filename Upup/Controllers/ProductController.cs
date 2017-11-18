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

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult GetAllProductInCart(JQueryDataTableParamModel param)
        {
            var productsInCart = new List<ProductCartViewModel>{
                new ProductCartViewModel {
                    AutoIdentity = 1,
                    ProductCode = "OS2203",
                    Quantity = 10,
                    Etc = "Máy",
                    ProductName = "Máy khoan cắt bê tông",
                    ProductPrice = 1200000,
                    TotalPrice = 12000000,
                    DeliveryDate = new DateTime(2017, 11, 30)
                },
                new ProductCartViewModel {
                    AutoIdentity = 2,
                    ProductCode = "TV2401",
                    Quantity = 100,
                    Etc = "Cái",
                    ProductName = "Ốc vít 6 cạnh TVA",
                    ProductPrice = 24000,
                    TotalPrice = 2400000,
                    DeliveryDate = new DateTime(2017, 11, 28)
                }
            };
            var result = productsInCart.Select(product => new[]
            {
                string.Empty, product.AutoIdentity.ToString(), product.ProductCode, product.Quantity.ToString(),
                product.Etc, product.ProductName, product.ProductPrice.ToString("N0"), product.TotalPrice.ToString("N0"), product.DeliveryDate.ToShortDateString()
            });
            return Json(new
            {
                param.sEcho,
                iTotalRecords = productsInCart.Count(),
                iTotalDisplayRecords = productsInCart.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}