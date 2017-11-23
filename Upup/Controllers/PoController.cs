using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using System.IO;
using System;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Customer")]
    public class PoController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SavePO(string code, string name)
        {
            CreatePO(code, name, true);
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Order(string code, string name)
        {
            CreatePO(code, name, false);
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult RequestPrice(string code, string name)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var CustomerRole = Db.Roles.First(r => r.Name == "Admin");
            var allAdmins = Db.Users.Where(u => u.Roles.Any(r => r.RoleId == CustomerRole.Id)).ToList();
            CreatePO(code, name, true);

            foreach (var admin in allAdmins)
            {
                UserManager.SendEmailAsync(admin.Id, $"có khách hàng {admin.FullName} cần báo giá", $"Họ tên: {user.FullName}, Điện thoại: {user.PhoneNumber}, Email:{user.Email}. Với chi tiết như sau </br>" + CreateEmailQuoteBody()).Wait();
            }

            UserManager.SendEmailAsync(user.Id, "Ghi nhận báo giá từ Upup", CreateEmailQuoteBody()).Wait();
            return RedirectToAction("Index");
        }

        private string CreateEmailQuoteBody()
        {
            string body = string.Empty;
            var userId = User.Identity.GetUserId();
            var user = Db.Customers.Find(userId);
            var carts = user.ProductCarts.ToList();
            int sequence = 0;
            var cartItems = new List<ProductCartItemModel>();

            foreach (var c in carts)
            {
                cartItems.Add(new ProductCartItemModel
                {
                    Id = c.Id,
                    Sequence = ++sequence,
                    DeliveryDate = c.CalculateShipDate(),
                    Quantity = c.Quantity,
                    BrandName = c.ProductVariant.BrandName,
                    ProductCode = c.ProductVariant.Product.Code,
                    ProductName = c.ProductVariant.Product.Name,
                    ProductPrice = c.ProductVariant.Price,
                    ProductVariantCode = c.ProductVariant.VariantCode,
                    ProductVariantName = c.ProductVariant.VariantName,
                    TotalPrice = c.CalculateTotalAmount(),
                    UnitName = c.ProductVariant.ProductVariantUnit.Name
                });
            }

            var html = string.Empty;
            decimal totalPrice = 0;
            if (cartItems != null)
            {
                var countProduct = 0;
                foreach (var product in cartItems)
                {
                    countProduct++;
                    html += "<tr>";
                    html += "<td rowspan = '3' style='width:5%;text-align:center;'> " + countProduct + " </td>";
                    html += "<td style ='width:38%'>" + product.ProductName + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:right'>" + product.BrandName + "</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:38%' >" + product.ProductCode + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:center' >" + product.DeliveryDate + "</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:30%; text-align:center' > " + product.ProductPrice + " </td>";
                    html += "<td style = 'width:20%; text-align:center' > " + product.Quantity + "";
                    html += "<td style = 'width:45%; text-align:right' > " + product.TotalPrice + " </td>";
                    html += "</tr > ";
                    totalPrice += product.TotalPrice;
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/QuotesTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[QuoteCode]", "123456");
            body = body.Replace("[QuoteDate]", DateTime.Now.ToShortDateString());
            body = body.Replace("[Barcode]", "0987654321");
            body = body.Replace("[PORef]", "00000000");
            body = body.Replace("[CustomerCode]", user.Code);
            body = body.Replace("[CustomerName]", user.FullName);
            body = body.Replace("[CompanyPhone]", user.PhoneNumber);
            body = body.Replace("[TaxNo]", user.OrgName);
            body = body.Replace("[CompanyAddress]", user.Address2);
            body = body.Replace("[ContactName]", user.OrgName);
            body = body.Replace("[Email]", user.Email);
            body = body.Replace("[Phone]", user.PhoneNumber);
            body = body.Replace("[Address]", user.Address1);
            body = body.Replace("[PayBeforeShip]", "X");
            body = body.Replace("[PayAfterShip]", string.Empty);
            body = body.Replace("[Amount]", totalPrice.ToString("N0"));
            body = body.Replace("[VAT]", "10%");
            body = body.Replace("[DeliveryFee]", "10000");
            body = body.Replace("[TotalAmount]", (totalPrice - (totalPrice*10/100) - 10000).ToString("N0"));
            body = body.Replace("[HtmlItemInGrid]", html);
            return body;
        }

        private PurchaseOrder CreatePO(string code, string name, bool isTemp)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var carts = user.ProductCarts.ToList();

            PurchaseOrder po = new PurchaseOrder
            {
                Code = code,
                Name = name,
                State = isTemp ? (int)PoState.Temp : (int)PoState.Ordered,
                PurchaseOrderDetails = carts.Select(c => new PurchaseOrderDetail
                {
                    Product = c.ProductVariant,
                    Quantity = c.Quantity,
                    ShipDate = c.CalculateShipDate(),
                    State = isTemp ? (int)PoDetailState.Temp : (int)PoDetailState.Ordered
                })
            };

            user.PurchaseOrders.Add(po);

            user.ProductCarts.Clear();

            Db.SaveChanges();
            return po;
        }
    }


    public class PoApiController : UpupApiControllerBase
    {
        public DataTableResponse<TableDataRow<PoItemModel>> GetAllPo()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var allpo = user.PurchaseOrders.ToList();

            int sequence = 0;
            List<TableDataRow<PoItemModel>> poItems = new List<TableDataRow<PoItemModel>>();
            foreach (var po in allpo)
            {
                poItems.Add(new TableDataRow<PoItemModel>
                {
                    DT_RowData = new PoItemModel
                    {
                        Code = po.Code,
                        Id = po.Id,
                        Name = po.Name,
                        State = po.State,
                        Sequence = ++sequence,
                        ShipingProgress = $"{po.CalculateShipping()}/{po.CalculateTotalDetail()}",
                        CompleteProgress = $"{po.CalculateCompleteShipping()}/{po.CalculateTotalDetail()}",
                        Ordered = po.State >= (int)PoState.Ordered,
                        Paid = po.State >= (int)PoState.Paid
                    }
                });
            }

            return new DataTableResponse<TableDataRow<PoItemModel>>
            {
                data = poItems,
                recordsTotal = poItems.Count(),
                recordsFiltered = poItems.Count()
            };
        }

        public class PoItemModel
        {
            public string Code { get; internal set; }
            public long Id { get; internal set; }
            public string Name { get; internal set; }
            public int State { get; internal set; }
            public int Sequence { get; internal set; }
            public string ShipingProgress { get; internal set; }
            public string CompleteProgress { get; internal set; }
            public bool Ordered { get; internal set; }
            public bool Paid { get; internal set; }
        }

    }

}