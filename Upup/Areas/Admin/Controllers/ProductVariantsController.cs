using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class ProductVariantsController : AdminControllerBase
    {
        [HttpPost]
        public ActionResult UpdateProductVariants(int id, string productId, string name, string code, string price,
            string onHand, string url2d, string url3d, string brandName, string orgin, string unitId, string[] settingIds)
        {
            var unit = Db.ProductVariantUnits.Find(Convert.ToInt32(unitId));
            var settings = new List<ShipDateSetting>();
            if (settingIds != null)
            {
                foreach (var setId in settingIds)
                {
                    var set = Db.ShipDateSettings.Find(setId);
                    settings.Add(set);
                }
            }
            var result = new AjaxSimpleResultModel();
            try
            {
                var productVariant = Db.ProductVariants.Find(id);
                if (productVariant == null)
                {
                    Db.ProductVariants.Add(new ProductVariant
                    {
                        ProductId = Convert.ToInt32(productId),
                        VariantName = name,
                        VariantCode = code,
                        Price = Convert.ToDecimal(price),
                        OnHand = Convert.ToDecimal(onHand),
                        Cad2dUrl = url2d,
                        Cad3dUrl = url3d,
                        BrandName = brandName,
                        Origin = orgin,
                        ProductVariantUnit = unit,
                        ShipdateSettings = settings
                    });
                    Db.SaveChanges();
                    result.ResultValue = true;
                    result.Message = "Đã thêm thành công biến thể !";
                }
                else
                {
                    productVariant.ProductId = Convert.ToInt32(productId);
                    productVariant.VariantName = name;
                    productVariant.VariantCode = code;
                    productVariant.Price = Convert.ToDecimal(price);
                    productVariant.OnHand = Convert.ToDecimal(onHand);
                    productVariant.Cad2dUrl = url2d;
                    productVariant.Cad3dUrl = url3d;
                    productVariant.BrandName = brandName;
                    productVariant.Origin = orgin;
                    productVariant.ProductVariantUnit = unit;
                    productVariant.ShipdateSettings = settings;
                    Db.Entry(productVariant).State = EntityState.Modified;
                    Db.SaveChanges();
                    result.ResultValue = true;
                    result.Message = "Cập nhật thành công biến thể !";
                }
            }
            catch (Exception)
            {
                result.ResultValue = false;
                result.Message = "Đã có lỗi xảy ra trong quá trình thực thi";
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult GetProductVariantById(int id)
        {
            var result = Mapper.Map<ProductVariant, ProductVariantModel>(Db.ProductVariants.Find(id));
            return Json(result);
        }

        [HttpPost]
        public ActionResult RemoveProductVariants(int id)
        {
            var result = new AjaxSimpleResultModel();
            var Product = Db.ProductVariants.ToList().SingleOrDefault(c => c.Id == id);
            if (Product != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "Biến thể bạn chọn đã được xóa thành công !";
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
                result.Message = "Biến thể bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/ProductVariants
        public ActionResult Index()
        {
            return View(Db.ProductVariants.ToList());
        }

        // GET: Admin/ProductVariants/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = Db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            return View(productVariant);
        }

        // GET: Admin/ProductVariants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductVariants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VariantName,VariantCode,Price,OnHand,Cad2dUrl,Cad3dUrl,BrandName,Origin")] ProductVariant productVariant)
        {
            if (ModelState.IsValid)
            {
                Db.ProductVariants.Add(productVariant);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productVariant);
        }

        // GET: Admin/ProductVariants/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = Db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            return View(productVariant);
        }

        // POST: Admin/ProductVariants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VariantName,VariantCode,Price,OnHand,Cad2dUrl,Cad3dUrl,BrandName,Origin")] ProductVariant productVariant)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(productVariant).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVariant);
        }

        // GET: Admin/ProductVariants/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVariant productVariant = Db.ProductVariants.Find(id);
            if (productVariant == null)
            {
                return HttpNotFound();
            }
            return View(productVariant);
        }

        // POST: Admin/ProductVariants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductVariant productVariant = Db.ProductVariants.Find(id);
            Db.ProductVariants.Remove(productVariant);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
