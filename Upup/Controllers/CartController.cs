using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Upup.Models;
using Upup.Utils;
using Upup.ViewModels;
using System.Data.Entity;

namespace Upup.Controllers
{
    public class CartController : UpupControllerBase
    {
        public System.Web.Mvc.ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            return View(user);
        }

    }

    public class CartApiController : UpupAPIControllerBase
    {
        public DataTableResponse<TableDataRow<ProductCartItemModel>> GetAllProductInCart()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var carts = user.ProductCarts.ToList();

            var cartItems = carts.Select(c => new TableDataRow<ProductCartItemModel>
            {
                DT_RowData = new ProductCartItemModel
                {
                    Id = c.Id,
                    DeliveryDate = c.CalculateShipDate(),
                    Quantity = c.Quantity,
                    ProductCode = c.ProductVariant.Product.Code,
                    ProductName = c.ProductVariant.Product.Name,
                    ProductPrice = c.ProductVariant.Price,
                    ProductVariantCode = c.ProductVariant.VariantCode,
                    ProductVariantName = c.ProductVariant.VariantName,
                    TotalPrice = c.CalculateTotalAmount(),
                    UnitName = c.ProductVariant.ProductVariantUnit.Name
                }
            });

            return new DataTableResponse<TableDataRow<ProductCartItemModel>>
            {
                data = cartItems,
                recordsTotal = cartItems.Count(),
                recordsFiltered = cartItems.Count()
            };
        }

        [System.Web.Http.HttpPost]
        public AjaxSimpleResultModel Add([FromBody]AddCartModel model)
        {
            var userId = User.Identity.GetUserId();

            var customer = Db.Customers.Find(userId);

            var variant = Db.ProductVariants.Find(model.productVariantId);
            if (variant == null) return new AjaxSimpleResultModel
            {
                Message = "Sản phẩm không tồn tại",
                ResultValue = false
            };

            var exists = customer.ProductCarts.FirstOrDefault(c => c.ProductVariant.Id == model.productVariantId);

            if (exists == null)
            {
                customer.ProductCarts.Add(new ProductCart
                {
                    ProductVariant = variant,
                    Quantity = (int)model.quantity
                });
            }
            else
            {
                exists.Quantity += (int)model.quantity;
            }

            Db.SaveChanges();

            return new AjaxSimpleResultModel
            {
                ResultValue = true,
                Message = "Thêm sản phẩm vào giỏ hàng thành công"
            };
        }

        public class AddCartModel
        {
            public long productVariantId { get; set; }
            public long quantity { get; set; }
        }
    }
}