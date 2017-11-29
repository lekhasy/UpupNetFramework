using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using Upup.ViewModels;
using System.Data.Entity;

namespace Upup.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Customer")]
    public class CartController : UpupControllerBase
    {
        [System.Web.Mvc.Authorize(Roles = "Customer")]
        public System.Web.Mvc.ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            return View(user);
        }

        [System.Web.Mvc.Authorize(Roles = "Customer")]
        public ActionResult AddToOldPo(int chosenOldPoId, int productVariantCode, int productVariantQuantity)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var oldPo = user.PurchaseOrders.FirstOrDefault(p => p.Id == chosenOldPoId);
            if (oldPo == null)
            {
                return RedirectToAction("Index");
            }

            // save this cart to temp PO
            var now = DateTime.Now;
            new CommonPoLogic(Db).CreatePO(DateTime.Now.ToString("yyMMddhhmmss"), $"TempPO_{DateTime.Now.ToString("yyMMddhhmmss")}", true, User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
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

            var addToCartResult = new CommonCartLogic(Db).AddToCart(customer, model.productVariantCode, (int)model.quantity);

            if (addToCartResult.ResultValue)
                Db.SaveChanges();

            return addToCartResult;

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

    public class CommonCartLogic
    {
        ApplicationDbContext _db;
        public CommonCartLogic(ApplicationDbContext Db)
        {

            _db = Db;
        }

        public AjaxSimpleResultModel AddToCart(Customer customer, string variantCode, int quantity)
        {
            var variant = _db.ProductVariants.FirstOrDefault(pv => pv.VariantCode == variantCode);
            if (variant == null) return new AjaxSimpleResultModel
            {
                Message = "Sản phẩm không tồn tại",
                ResultValue = false
            };

            var exists = customer.ProductCarts.FirstOrDefault(c => c.ProductVariant.VariantCode == variantCode);

            if (exists == null)
            {
                customer.ProductCarts.Add(new ProductCart
                {
                    ProductVariant = variant,
                    Quantity = quantity
                });
            }
            else
            {
                exists.Quantity += quantity;
            }

            return new AjaxSimpleResultModel
            {
                ResultValue = true,
                Message = "Thêm sản phẩm vào giỏ hàng thành công"
            };
        }
    }
}