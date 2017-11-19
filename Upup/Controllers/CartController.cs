using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using Upup.ViewModels;
using System.Data.Entity;

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
        public DataTableResponse<ProductCartItemModel> GetAllProductInCart(DataTableRequest req)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var carts = user.ProductCarts.ToList();

            var cartItems = carts.Select(c => new ProductCartItemModel
            {
                Id = c.Id,
                DeliveryDate = c.CalculateShipDate(),
                Quantity = c.Quantity,
                ProductCode = c.ProductVariant.Product.Code,
                ProductName = c.ProductVariant.Product.Name,
                ProductPrice = c.ProductVariant.Price,
                ProductVariantCode = c.ProductVariant.VariantCode,
                TotalPrice = c.CalculateTotalAmount(),
                UnitName = c.ProductVariant.ProductVariantUnit.Name
            });

            return new DataTableResponse<ProductCartItemModel>
            {
                draw = req.draw,
                data = cartItems,
                recordsTotal = cartItems.Count(),
                recordsFiltered = cartItems.Count()
            };
        }

        private IEnumerable<ProductCartItemModel> GetAllProductCart()
        {
            return new List<ProductCartItemModel>{
                new ProductCartItemModel {
                    Id = 1,
                    ProductCode = "OS2203",
                    Quantity = 10,
                    UnitName = "Máy",
                    ProductName = "Máy khoan cắt bê tông",
                    ProductPrice = 1200000,
                    TotalPrice = 12000000,
                    DeliveryDate = new DateTime(2017, 11, 30)
                },
                new ProductCartItemModel {
                    Id = 2,
                    ProductCode = "TV2401",
                    Quantity = 100,
                    UnitName = "Cái",
                    ProductName = "Ốc vít 6 cạnh TVA",
                    ProductPrice = 24000,
                    TotalPrice = 2400000,
                    DeliveryDate = new DateTime(2017, 11, 28)
                }
            };
        }
    }
}