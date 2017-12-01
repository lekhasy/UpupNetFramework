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
            var allPO = GetAllPo();

            return View(allPO);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SavePO(string code, string name)
        {
            new  CommonPoLogic(Db).CreatePO(code, name, true,  User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Order(string code, string name)
        {
            new CommonPoLogic(Db).CreatePO(code, name, false, User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult RequestPrice(string code, string name)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            //var CustomerRole = Db.Roles.First(r => r.Name == "Admin");
            //var allAdmins = Db.Users.Where(u => u.Roles.Any(r => r.RoleId == CustomerRole.Id)).ToList();
            //foreach (var admin in allAdmins)
            //{
            //    UserManager.SendEmailAsync(admin.Id, $"có khách hàng {admin.FullName} cần báo giá", $"Họ tên: {user.FullName}, Điện thoại: {user.PhoneNumber}, Email:{user.Email}. Với chi tiết như sau </br>" + CreateEmailQuoteBody()).Wait();
            //}

            UserManager.SendEmailAsync(user.Id, "Báo giá từ Upup", CreateEmailQuoteBody()).Wait();
            new CommonPoLogic(Db).CreatePO(code, name, true, User.Identity.GetUserId());
            Db.SaveChanges();
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
                    html += "<td style = 'width:30%; text-align:center' > " + product.ProductPrice.ToString("N0") + " </td>";
                    html += "<td style = 'width:20%; text-align:center' > " + product.Quantity + "";
                    html += "<td style = 'width:45%; text-align:right' > " + product.TotalPrice.ToString("N0") + " </td>";
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
            body = body.Replace("[DeliveryFee]", "10,000");
            body = body.Replace("[TotalAmount]", (totalPrice + (totalPrice*10/100) + 10000).ToString("N0"));
            body = body.Replace("[HtmlItemInGrid]", html);
            return body;
		}
		
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(long id)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var po = user.PurchaseOrders.FirstOrDefault(p => p.Id == id);

            if (po == null || (po.State != (int)PoState.Temp && po.State != (int)PoState.Completed))
            {
                return RedirectToAction("Index");
            }

            Db.PurchaseOrderDetail.RemoveRange(po.PurchaseOrderDetails);
            user.PurchaseOrders.Remove(po);
            Db.PurchaseOrders.Remove(po);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Detail(long id)
        {
            var userId = User.Identity.GetUserId();
            
            var user = Db.Customers.Find(userId);

            var po = user.PurchaseOrders.FirstOrDefault(p => p.Id == id);

            return View(po);
        }

        
        

        public IEnumerable<PoItemModel> GetAllPo()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var allpo = user.PurchaseOrders.ToList();

            int sequence = 0;
            List<PoItemModel> poItems = new List<PoItemModel>();
            foreach (var po in allpo)
            {
                poItems.Add(
                    new PoItemModel
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
                );
            }

            return poItems;
        }
    }

    public class PoApiController : UpupApiControllerBase
    {
        [System.Web.Http.HttpGet]
        public DataTableResponse<TableDataRow<PoItemModel>> GetAllUnPaidPo()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var allpo = user.PurchaseOrders.Where(p => p.State < (int)PoState.Paid).ToList();

            int sequence = 0;
            List<PoItemModel> poItems = new List<PoItemModel>();
            foreach (var po in allpo)
            {
                poItems.Add(
                    new PoItemModel
                    {
                        Code = po.Code,
                        Id = po.Id,
                        Name = po.Name,
                        State = po.State,
                        Sequence = ++sequence,
                        ShipingProgress = $"{po.CalculateShipping()}/{po.CalculateTotalDetail()}",
                        CompleteProgress = $"{po.CalculateCompleteShipping()}/{po.CalculateTotalDetail()}",
                        Ordered = po.State >= (int)PoState.Ordered,
                        Paid = po.State >= (int)PoState.Paid,
                        CreatedDate = po.CreatedDate
                    }
                );
            }



            var tablePoItem = poItems.Select(poi => new TableDataRow<PoItemModel> {
                 DT_RowData = poi 
            });

            return new DataTableResponse<TableDataRow<PoItemModel>>
            {
                data = tablePoItem
            };
        }
    }

    public class CommonPoLogic
    {
        ApplicationDbContext _db;
        public CommonPoLogic(ApplicationDbContext Db)
        {
            _db = Db;
        }

        public PurchaseOrder CreatePO(string code, string name, bool isTemp, string customerId)
        {
            var customer = _db.Customers.Find(customerId);

            var carts = customer.ProductCarts.ToList();

            if (!carts.Any())
            {
                return null;
            }

            PurchaseOrder po = new PurchaseOrder
            {
                Code = code,
                Name = name,
                State = isTemp ? (int)PoState.Temp : (int)PoState.Ordered,
                CreatedDate = DateTime.Now,
                PurchaseOrderDetails = carts.Select(c => new PurchaseOrderDetail
                {
                    Product = c.ProductVariant,
                    Quantity = c.Quantity,
                    ShipDate = c.CalculateShipDate(),
                    State = isTemp ? (int)PoDetailState.Temp : (int)PoDetailState.Ordered
                }).ToList()
            };

            customer.PurchaseOrders.Add(po);
            customer.ProductCarts.Clear();
            _db.ProductCarts.RemoveRange(carts);
            customer.TempPoName = null;
            return po;
        }

    }

}