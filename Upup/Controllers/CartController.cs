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

    public class CartApiController : UpupApiControllerBase
    {
        public DataTableResponse<TableDataRow<ProductCartItemModel>> GetAllProductInCart()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var carts = user.ProductCarts.ToList();

            int sequence = 0;
            List<TableDataRow<ProductCartItemModel>> cartItems = new List<TableDataRow<ProductCartItemModel>>();

            foreach (var c in carts)
            {
                cartItems.Add(new TableDataRow<ProductCartItemModel>
                {
                    DT_RowData = new ProductCartItemModel
                    {
                        Id = c.Id,
                        Sequence = ++sequence,
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
            }

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

            var variant = Db.ProductVariants.FirstOrDefault(pv => pv.VariantCode == model.productVariantCode);
            if (variant == null) return new AjaxSimpleResultModel
            {
                Message = "Sản phẩm không tồn tại",
                ResultValue = false
            };

            var exists = customer.ProductCarts.FirstOrDefault(c => c.ProductVariant.VariantCode == model.productVariantCode);

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

        [System.Web.Http.HttpPost]
        public AjaxSimpleResultModel RemoveItems([FromBody]RemoveCartModel model)
        {
            var userId = User.Identity.GetUserId();

            var customer = Db.Customers.Find(userId);

            var removing = customer.ProductCarts.Where(c => model.ids.Contains(c.Id)).ToList();

            foreach (var item in removing)
            {
                customer.ProductCarts.Remove(item);
            }

            Db.SaveChanges();

            return new AjaxSimpleResultModel
            {
                ResultValue = true,
                Message = "Xóa thành công"
            };
        }


        public class AddCartModel
        {
            public string productVariantCode { get; set; }
            public long quantity { get; set; }
        }

        public class RemoveCartModel
        {
            public long[] ids { get; set; }
        }
    }
}