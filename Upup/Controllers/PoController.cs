using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using System.IO;
using System;

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
                UserManager.SendEmailAsync(admin.Id, $"có khách hàng {admin.FullName} cần báo giá", $"Họ tên: {user.FullName}, Điện thoại: {user.PhoneNumber}, Email:{user.Email}").Wait();
            }

            UserManager.SendEmailAsync(user.Id, "Ghi nhận báo giá từ Upup", "Yêu cầu báo giá của bạn đả được chúng tôi ghi nhận, chúng tôi sẽ liên hệ bạn ngay khi có thể.").Wait();
            return RedirectToAction("Index");
        }

        private string CreateEmailQuoteBody(string userName, string code, string title, string message)
        {
            string body = string.Empty;
            var userId = User.Identity.GetUserId();
            var user = Db.Customers.Find(userId);
            var carts = user.ProductCarts.ToList();
            if (carts != null)
            {
                var html = string.Empty;
                var countProduct = 0;
                foreach (var product in carts)
                {
                    countProduct++;
                    html += "<tr>";
                    html += "<td rowspan = '3' style='width:5%;text-align:center;'> " + countProduct + " </td>";
                    html += "<td style ='width:38%'> TÊN SẢN PHẨM</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:right'> Nhãn hiệu </td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:38%' > Mã sản phẩm</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:center' > Thời gian giao hàng </td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:30%; text-align:center' > Đơn giá(vnd) </td>";
                    html += "<td style = 'width:20%; text-align:center' > Số lượng </td>";
                    html += "<td style = 'width:45%; text-align:right' > Tổng tiền(vnd) </td>";
                    html += "</tr > ";
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/QuotesTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[QuoteCode]", "123456");
            body = body.Replace("[QuoteDate]", DateTime.Now.ToShortDateString());
            body = body.Replace("[Barcode]", "0987654321");
            body = body.Replace("[PORef]", "123456");
            body = body.Replace("[CustomerCode]", DateTime.Now.ToShortDateString());
            body = body.Replace("[CustomerName]", "0987654321");
            body = body.Replace("[CompanyPhone]", "123456");
            body = body.Replace("[TaxNo]", DateTime.Now.ToShortDateString());
            body = body.Replace("[CompanyAddress]", "0987654321");
            body = body.Replace("[ContactName]", "123456");
            body = body.Replace("[Email]", DateTime.Now.ToShortDateString());
            body = body.Replace("[Phone]", "0987654321");
            body = body.Replace("[Address]", "0987654321");
            body = body.Replace("[PayBeforeShip]", "0987654321");
            body = body.Replace("[PayAfterShip]", "0987654321");
            body = body.Replace("[Amount]", "0987654321");
            body = body.Replace("[VAT]", "0987654321");
            body = body.Replace("[DeliveryFee]", "0987654321");
            body = body.Replace("[TotalAmount]", "0987654321");
            body = body.Replace("[HtmlItemInGrid]", "0987654321");
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