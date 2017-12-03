using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class PurchaseOrdersController : AdminControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ManagePO()
        {
            var po = new PurchaseOrderDetailModel();


            return View(po);
        }

        [HttpGet]
        public ActionResult LoadAllPO(JQueryDataTableParamModel param)
        {
            var listPO = new List<PurchaseOrderDetailModel>();
            var purchaseOrders = Db.PurchaseOrders.ToList();
            var users = Db.Users.ToList();
            var products = Db.Products.ToList();
            foreach (var po in purchaseOrders)
            {
                var pods = po.PurchaseOrderDetails;
                listPO.Add(new PurchaseOrderDetailModel
                {
                    Id = po.Id,
                    Code = po.Code,
                    CreatedDate = po.CreatedDate,
                    Name = po.Name,
                    IsDeleted = po.IsDeleted,
                    State = po.State,
                    Customer = po.Customer,
                    TotalAmount = po.TotalAmount
                });
            }
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                listPO = listPO
                         .Where(c => c.Code.Contains(param.sSearch)
                                     ||
                                     c.CreatedDate.ToShortDateString().Contains(param.sSearch)
                          ||
                          c.Name.Contains(param.sSearch)
                          ||
                          c.Customer.FullName.Contains(param.sSearch)).ToList();
            }
            var filteredProducts = listPO.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PurchaseOrderDetailModel, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Code :
                                                                sortColumnIndex == 2 ? n.Name :
                                                                sortColumnIndex == 3 ? n.Customer.FullName : n.TotalAmount.ToString("N0"));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProducts = sortDirection == "asc" ? filteredProducts.OrderBy(orderingFunction) : filteredProducts.OrderByDescending(orderingFunction);

            var result = filteredProducts.Select(Po => new[]
            {
                Po.Id.ToString(CultureInfo.InvariantCulture), Po.Code, Po.CreatedDate.ToShortDateString(), Po.Name,
                Po.State.ToString(), Po.Customer.FullName, Po.TotalAmount.ToString("N0"),
                Po.IsDeleted.ToString(CultureInfo.InvariantCulture), Po.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = listPO.Count(),
                iTotalDisplayRecords = listPO.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemovePO(int id)
        {
            var result = new AjaxSimpleResultModel();
            var po = Db.PurchaseOrders.SingleOrDefault(c => c.Id == id);
            if (po != null)
            {
                try
                {
                    if (po.IsTemp)
                    {
                        DeleteConfirmed(id);
                    }
                    else {
                        po.IsDeleted = true;
                        db.Entry(po).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    
                    result.ResultValue = true;
                    result.Message = "đơn hàng bạn chọn đã được xóa thành công !";
                }
                catch (Exception)
                {
                    result.ResultValue = false;
                    result.Message = "Đã có lỗi xảy ra trong quá trình thực thi";
                    return Json(result);
                }
            }
            else
            {
                result.ResultValue = false;
                result.Message = "đơn hàng bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/PurchaseOrders
        public ActionResult Index()
        {
            return View(db.PurchaseOrders.ToList());
        }

        // GET: Admin/PurchaseOrders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,State")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: Admin/PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,State")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: Admin/PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
