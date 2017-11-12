using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class ProductVariantsController : AdminControllerBase
    {
        //[HttpPost]
        //public ActionResult CreateProductVariant() {

        //}

        //[HttpPost]
        //public ActionResult RemoveProducts(int id)
        //{
        //    var result = new AjaxSimpleResultModel();
        //    var Product = Db.Products.ToList().SingleOrDefault(c => c.Id == id);
        //    if (Product != null)
        //    {
        //        try
        //        {
        //            DeleteConfirmed(id);
        //            result.ResultValue = true;
        //            result.Message = "sản phẩm bạn chọn đã được xóa thành công !";
        //        }
        //        catch (Exception)
        //        {
        //            result.ResultValue = false;
        //            result.Message = "Đã có lỗi xảy ra trong quá trình thực thi";
        //            return Json(result);
        //        }
        //    }
        //    else
        //    {
        //        result.ResultValue = false;
        //        result.Message = "sản phẩm bạn chọn đã bị xóa hoặc không tồn tại";
        //    }
        //    return Json(result);
        //}

        //// GET: Admin/ProductVariants
        //public ActionResult Index()
        //{
        //    return View(Db.ProductCustomProperties.ToList());
        //}

        //// GET: Admin/ProductVariants/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductVariant productVariant = Db.ProductCustomProperties.Find(id);
        //    if (productVariant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productVariant);
        //}

        //// GET: Admin/ProductVariants/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/ProductVariants/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,VariantName,VariantCode,Price,OnHand,Cad2dUrl,Cad3dUrl,BrandName,Origin")] ProductVariant productVariant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Db.ProductCustomProperties.Add(productVariant);
        //        Db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(productVariant);
        //}

        //// GET: Admin/ProductVariants/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductVariant productVariant = Db.ProductCustomProperties.Find(id);
        //    if (productVariant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productVariant);
        //}

        //// POST: Admin/ProductVariants/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,VariantName,VariantCode,Price,OnHand,Cad2dUrl,Cad3dUrl,BrandName,Origin")] ProductVariant productVariant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Db.Entry(productVariant).State = EntityState.Modified;
        //        Db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(productVariant);
        //}

        //// GET: Admin/ProductVariants/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductVariant productVariant = Db.ProductCustomProperties.Find(id);
        //    if (productVariant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productVariant);
        //}

        //// POST: Admin/ProductVariants/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    ProductVariant productVariant = Db.ProductCustomProperties.Find(id);
        //    Db.ProductCustomProperties.Remove(productVariant);
        //    Db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
