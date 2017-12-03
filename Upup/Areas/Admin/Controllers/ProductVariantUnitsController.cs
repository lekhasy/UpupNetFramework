using AutoMapper;
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
    public class ProductVariantUnitsController : AdminControllerBase
    {
        [HttpGet]
        public ActionResult ManageProductVariantUnits(int? id)
        {
            var allProductVariantUnits = Mapper.Map<List<ProductVariantUnit>, List<ProductVariantUnitModel>>(Db.ProductVariantUnits.ToList());
            var model = new ProductVariantUnitModel
            {
                AllProductVariantUnit = allProductVariantUnits
            };
            if (id == null) return View(model);
            var result = Db.ProductVariantUnits.Find(id);
            if (result != null)
            {
                model = Mapper.Map<ProductVariantUnit, ProductVariantUnitModel>(result);
                return View(model);
            }
            ModelState.AddModelError("ProgressError", "Đơn vị bạn chọn đã bị xóa hoặc không tồn tại");
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManageProductVariantUnits(ProductVariantUnitModel model)
        {
            var allProductVariantUnits = Mapper.Map<List<ProductVariantUnit>, List<ProductVariantUnitModel>>(Db.ProductVariantUnits.ToList());
            model.AllProductVariantUnit = allProductVariantUnits;
            var parentProductVariantUnit = Db.ProductVariantUnits.Find(model.Id);
            if (model.Id == 0)
            {
                var ProductVariantUnit = new ProductVariantUnit
                {
                    Name = model.Name
                };
                try
                {
                    Db.ProductVariantUnits.Add(ProductVariantUnit);
                    Db.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 Đơn vị mới !");
            }
            else
            {
                var productVariantUnit = Db.ProductVariantUnits.Find(model.Id);
                if (productVariantUnit != null)
                {
                    productVariantUnit.Name = model.Name;
                    try
                    {
                        Db.Entry(productVariantUnit).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho Đơn vị !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "Đơn vị bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            return View(model);
        }

        [HttpGet]

        public ActionResult LoadAllProductVariantUnits(JQueryDataTableParamModel param)
        {
            var allProductVariantUnits = Db.ProductVariantUnits.ToList();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                allProductVariantUnits = Db.ProductVariantUnits.ToList()
                         .Where(c => c.Name.Contains(param.sSearch)).ToList();
            }
            var filteredProductVariantUnits = allProductVariantUnits.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ProductVariantUnit, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) : n.Name);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProductVariantUnits = sortDirection == "asc" ? filteredProductVariantUnits.OrderBy(orderingFunction) : filteredProductVariantUnits.OrderByDescending(orderingFunction);

            var result = filteredProductVariantUnits.Select(ProductVariantUnit => new[]
            {
                ProductVariantUnit.Id.ToString(CultureInfo.InvariantCulture), ProductVariantUnit.Name, ProductVariantUnit.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allProductVariantUnits.Count(),
                iTotalDisplayRecords = allProductVariantUnits.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveProductVariantUnits(int id)
        {
            var result = new AjaxSimpleResultModel();
            var ProductVariantUnit = Db.ProductVariantUnits.ToList().SingleOrDefault(c => c.Id == id);
            if (ProductVariantUnit != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "Đơn vị bạn chọn đã được xóa thành công !";
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
                result.Message = "Đơn vị bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductVariantUnits
        public ActionResult Index()
        {
            return View(db.ProductVariantUnits.ToList());
        }

        // GET: Admin/ProductVariantUnits/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariantUnit productVariantUnit = db.ProductVariantUnits.Find(id);
            if (productVariantUnit == null)
            {
                return HttpNotFound();
            }
            return View(productVariantUnit);
        }

        // GET: Admin/ProductVariantUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductVariantUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ProductVariantUnit productVariantUnit)
        {
            if (ModelState.IsValid)
            {
                db.ProductVariantUnits.Add(productVariantUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productVariantUnit);
        }

        // GET: Admin/ProductVariantUnits/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariantUnit productVariantUnit = db.ProductVariantUnits.Find(id);
            if (productVariantUnit == null)
            {
                return HttpNotFound();
            }
            return View(productVariantUnit);
        }

        // POST: Admin/ProductVariantUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProductVariantUnit productVariantUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productVariantUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVariantUnit);
        }

        // GET: Admin/ProductVariantUnits/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariantUnit productVariantUnit = db.ProductVariantUnits.Find(id);
            if (productVariantUnit == null)
            {
                return HttpNotFound();
            }
            return View(productVariantUnit);
        }

        // POST: Admin/ProductVariantUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductVariantUnit productVariantUnit = db.ProductVariantUnits.Find(id);
            db.ProductVariantUnits.Remove(productVariantUnit);
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
