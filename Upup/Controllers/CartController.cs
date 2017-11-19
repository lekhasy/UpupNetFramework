using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using Upup.ViewModels;

namespace Upup.Controllers
{
    public class CartController : UpupControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

    }

    public class CartApiController : UpupAPIControllerBase
    {
        public DataTableResponse<ProductCartItem> GetAllProductInCart(DataTableRequest req)
        {
            var productsInCart = GetAllProductCart();

            var result = productsInCart.Select(product => new[]
            {
                string.Empty, product.Id.ToString(), product.ProductCode, product.Quantity.ToString(),
                product.Etc, product.ProductName, product.ProductPrice.ToString("N0"), product.TotalPrice.ToString("N0"), product.DeliveryDate.ToShortDateString()
            });

            return new DataTableResponse<ProductCartItem>
            {
                //draw = req.draw,
                //data = result,
                //recordsTotal = count,
                //recordsFiltered = dataResultQuery.Count()
            };
        }

        private IEnumerable<ProductCartItem> GetAllProductCart()
        {
            return new List<ProductCartItem>{
                new ProductCartItem {
                    Id = 1,
                    ProductCode = "OS2203",
                    Quantity = 10,
                    Etc = "Máy",
                    ProductName = "Máy khoan cắt bê tông",
                    ProductPrice = 1200000,
                    TotalPrice = 12000000,
                    DeliveryDate = new DateTime(2017, 11, 30)
                },
                new ProductCartItem {
                    Id = 2,
                    ProductCode = "TV2401",
                    Quantity = 100,
                    Etc = "Cái",
                    ProductName = "Ốc vít 6 cạnh TVA",
                    ProductPrice = 24000,
                    TotalPrice = 2400000,
                    DeliveryDate = new DateTime(2017, 11, 28)
                }
            };
        }
    }
}