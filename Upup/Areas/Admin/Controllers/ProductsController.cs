using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class ProductsController : AdminControllerBase
    {
        [HttpGet]
        public ActionResult ManageProducts(int? id)
        {
            var categories = Db.Categories.ToList().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            categories.Insert(0, new SelectListItem
            {
                Text = "Chọn sản phẩm sản phẩm",
                Value = string.Empty,
                Selected = true
            });
            var product = new ProductModel { Categories = categories };
            if (id == null) return View(product);
            var result = Db.Products.Find(id);
            if (result != null)
            {
                product = Mapper.Map<Product, ProductModel>(result);
                var existProductCategory = Db.Categories.Find(product.Category_Id);
                if (existProductCategory == null)
                {
                    result.Category = null;
                    Db.Entry(result).State = EntityState.Modified;
                    Db.SaveChanges();
                }
                else
                {
                    product.Category_Id = Convert.ToInt32(result.Category.Id);
                }
                product.Categories = categories;
                return View(product);
            }
            ModelState.AddModelError("ProgressError", "sản phẩm bạn chọn đã bị xóa hoặc không tồn tại");
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManageProducts(ProductModel model)
        {
            var imgUrl = !string.IsNullOrEmpty(model.ImageUrl) ? model.ImageUrl : string.Empty;
            imgUrl = imgUrl.EndsWith(",") ? imgUrl.Remove(imgUrl.Length - 1, 1) : imgUrl;
            var keywords = model.MetaKeyword;
            var keywords2 = model.MetaKeyword_en;
            if (!string.IsNullOrEmpty(keywords))
            {
                keywords = keywords.EndsWith(",")
                    ? Regex.Replace(model.MetaKeyword, ",{2,}", ",").Trim(',')
                    : model.MetaKeyword;
            }
            if (!string.IsNullOrEmpty(keywords2))
            {
                keywords2 = keywords2.EndsWith(",")
                    ? Regex.Replace(model.MetaKeyword_en, ",{2,}", ",").Trim(',')
                    : model.MetaKeyword_en;
            }
            var category = Db.Categories.Find(model.Category_Id);
            //if (parentProduct == null)
            //    throw new Exception("sản phẩm cha có thể đã bị xóa!");
            if (model.Id == 0)
            {
                var Product = new Product
                {
                    Name = model.Name,
                    Name_en = model.Name_en,
                    Code = model.Code,
                    PdfUrl = model.PdfUrl,
                    Price = model.Price,
                    OnHand = model.OnHand,
                    Category = category,
                    MetaDescription = model.MetaDescription,
                    MetaKeyword = keywords,
                    MetaDescription_en = model.MetaDescription_en,
                    MetaKeyword_en = keywords2,
                    ImageUrl = imgUrl,
                };
                try
                {
                    Db.Products.Add(Product);
                    Db.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 tin tức mới !");
            }
            else
            {
                var product = Db.Products.Find(model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Name_en = model.Name_en;
                    product.ImageUrl = imgUrl;
                    product.Code = model.Code;
                    product.PdfUrl = model.PdfUrl;
                    product.Price = model.Price;
                    product.OnHand = model.OnHand;
                    product.Category = category;
                    product.MetaDescription = model.MetaDescription;
                    product.MetaKeyword = keywords;
                    product.MetaDescription_en = model.MetaDescription_en;
                    product.MetaKeyword_en = keywords2;
                    try
                    {
                        Db.Entry(product).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho sản phẩm !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "sản phẩm bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            ViewData["ProductImgUrl"] = "/Images/Product/" + imgUrl;
            return RedirectToAction("ManageProducts");
        }

        [HttpGet]

        public ActionResult LoadAllProducts(JQueryDataTableParamModel param)
        {
            var allProducts = Db.Products.ToList();
            List<Product> afterFound = new List<Product>();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                afterFound = Db.Products.ToList()
                         .Where(c => c.Name.Contains(param.sSearch)
                                     ||
                          c.Name_en.Contains(param.sSearch)
                                     ||
                          c.Price.ToString().Contains(param.sSearch)).ToList();
            }
            var filteredProducts = allProducts.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Product, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Name :
                                                                sortColumnIndex == 2 ? n.Name_en : n.Price.ToString());

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProducts = sortDirection == "asc" ? filteredProducts.OrderBy(orderingFunction) : filteredProducts.OrderByDescending(orderingFunction);

            var result = filteredProducts.Select(Product => new[]
            {
                Product.Id.ToString(CultureInfo.InvariantCulture), Product.Name, Product.Name_en, Product.Price.ToString(),
                Product.ImageUrl, Product.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allProducts.Count(),
                iTotalDisplayRecords = allProducts.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveProducts(int id)
        {
            var result = new AjaxSimpleResultModel();
            var Product = Db.Products.ToList().SingleOrDefault(c => c.Id == id);
            if (Product != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "sản phẩm bạn chọn đã được xóa thành công !";
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
                result.Message = "sản phẩm bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(Db.Products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Name_en,Price,OnHand")] Product product)
        {
            if (ModelState.IsValid)
            {
                Db.Products.Add(product);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Name_en,Price,OnHand")] Product product)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(product).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = Db.Products.Find(id);
            Db.Products.Remove(product);
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
