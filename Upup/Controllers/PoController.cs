using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class PoController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            return View(user);
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

            var listTask = new List<Task>();

            foreach (var admin in allAdmins)
            {
                UserManager.SendEmailAsync(admin.Id, $"có khách hàng {admin.FullName} cần báo giá", $"Họ tên: {user.FullName}, Điện thoại: {user.PhoneNumber}, Email:{user.Email}").Wait();
            }

            UserManager.SendEmailAsync(user.Id, "Ghi nhận báo giá từ Upup", "Yêu cầu báo giá của bạn đả được chúng tôi ghi nhận, chúng tôi sẽ liên hệ bạn ngay khi có thể.").Wait();
            return RedirectToAction("Index");
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
                State = isTemp? (int)PoState.Temp : (int)PoState.Processing,
                PurchaseOrderDetails = carts.Select(c => new PurchaseOrderDetail
                {
                    Product = c.ProductVariant,
                    Quantity = c.Quantity,
                    ShipDate = c.CalculateShipDate(),
                    State = (int)PoDetailState.New
                })
            };

            user.PurchaseOrders.Add(po);

            user.ProductCarts.Clear();

            Db.SaveChanges();
            return po;
        }
    }
}