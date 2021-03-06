﻿using AutoMapper;
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
            var variants = new List<ProductVariantModel>();
            var categories = Db.Categories.ToList().Where(cat => cat.ChildCategories.Count == 0)
                .Select(cat => new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            categories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục sản phẩm",
                Value = string.Empty,
                Selected = true
            });
            var units = Db.ProductVariantUnits.ToList()
                .Select(unit => new SelectListItem
                {
                    Text = unit.Name,
                    Value = unit.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            units.Insert(0, new SelectListItem
            {
                Text = "Chọn đơn vị tính",
                Value = string.Empty,
                Selected = true
            });
            var shipDateSettings = Db.ShipDateSettings.ToList()
                .Select(unit => new SelectListItem
                {
                    Text = "SL " + unit.QuantityOrderMax + " (" + unit.TargetDateNumber + " ngày)",
                    Value = unit.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            var product = new ProductModel
            {
                Categories = categories,
                ProductVariantUnits = units,
                ShipdateSettings = shipDateSettings,
                DefaultShipdateChoosen = string.Join(",", Db.ShipDateSettings.Select(ship => ship.Id)),
                Variants = variants
            };
            if (id == null) return View(product);
            var result = Db.Products.Find(id);
            if (result != null)
            {
                variants = Mapper.Map<List<ProductVariant>, List<ProductVariantModel>>(result.ProductVariants.ToList());
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
                product.ProductVariantUnits = units;
                product.ShipdateSettings = shipDateSettings;
                product.DefaultShipdateChoosen = string.Join(",", Db.ShipDateSettings.Select(ship => ship.Id));
                product.Variants = variants;
                return View(product);
            }
            ModelState.AddModelError("ProgressError", "sản phẩm bạn chọn đã bị xóa hoặc không tồn tại");
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManageProducts(ProductModel model)
        {
            var categories = Db.Categories.ToList().Where(cat => cat.ChildCategories.Count == 0)
                .Select(cat => new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            categories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục sản phẩm",
                Value = string.Empty,
                Selected = true
            });
            var units = Db.ProductVariantUnits.ToList()
                .Select(unit => new SelectListItem
                {
                    Text = unit.Name,
                    Value = unit.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            units.Insert(0, new SelectListItem
            {
                Text = "Chọn đơn vị tính",
                Value = string.Empty,
                Selected = true
            });
            var shipDateSettings = Db.ShipDateSettings.ToList()
                .Select(unit => new SelectListItem
                {
                    Text = "SL " + unit.QuantityOrderMax + " (" + unit.TargetDateNumber + " ngày)",
                    Value = unit.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();

            model.Categories = categories;
            model.ProductVariantUnits = units;
            model.ShipdateSettings = shipDateSettings;
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
            if (category.ChildCategories.Count > 0)
            {
                ModelState.AddModelError("ProgressError", "Danh mục bạn chọn đang chứa danh mục con, vui lòng chọn danh mục khác.");
            }
            else
            {
                Product product = null;
                if (model.Id == 0)
                {
                    //var productByCode = Db.Products.SingleOrDefault(p => p.Code == model.Code);

                    //if (productByCode != null)
                    //{
                    //    ModelState.AddModelError("ProgressError", "Mã sản phẩm này đã tồn tại, vui lòng chọn mã khác");
                    //    model.Variants = new List<ProductVariantModel>();
                    //    return View(model);
                    //}

                    var Product = new Product
                    {
                        Name = model.Name,
                        Name_en = model.Name_en,
                        //Code = model.Code,
                        PdfUrl = model.PdfUrl,
                        Summary = model.Summary,
                        Summary_en = model.Summary_en,
                        LinkGuide = model.LinkGuide,
                        //Cad2dUrl = model.Cad2dUrl,
                        //Cad3dUrl = model.Cad3dUrl,
                        //Price = model.Price,
                        //OnHand = model.OnHand,
                        Category = category,
                        MetaDescription = model.MetaDescription,
                        MetaKeyword = keywords,
                        MetaDescription_en = model.MetaDescription_en,
                        MetaKeyword_en = keywords2,
                        ImageUrl = imgUrl,
                    };
                    try
                    {
                        product = Db.Products.Add(Product);
                        Db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 sản phẩm mới !");
                }
                else
                {
                    product = Db.Products.Find(model.Id);
                    if (product != null)
                    {
                        if (!product.ImageUrl.Equals(imgUrl))
                        {
                            var fullPath = Server.MapPath(@"\Images\products\" + product.ImageUrl);
                            if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                            }
                        }
                        product.Name = model.Name;
                        product.Name_en = model.Name_en;
                        product.ImageUrl = imgUrl;
                        //product.Code = model.Code;
                        product.PdfUrl = model.PdfUrl;
                        product.Summary = model.Summary;
                        product.Summary_en = model.Summary_en;
                        product.LinkGuide = model.LinkGuide;
                        //product.Cad2dUrl = model.Cad2dUrl;
                        //product.Cad3dUrl = model.Cad3dUrl;
                        //product.Price = model.Price;
                        //product.OnHand = model.OnHand;
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
                var variants = Mapper.Map<List<ProductVariant>, List<ProductVariantModel>>(product.ProductVariants != null ? product.ProductVariants.ToList() : new List<ProductVariant>());
                model.Variants = variants;
            }
            ViewData["ProductImgUrl"] = "/Images/Product/" + imgUrl;
            return View(model);
        }

        [HttpGet]
        public ActionResult LoadAllProducts(JQueryDataTableParamModel param)
        {
            var allProducts = Db.Products.ToList();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                allProducts = Db.Products.ToList()
                         .Where(c => c.Name.Contains(param.sSearch)
                                     ||
                          c.Name_en.Contains(param.sSearch)).ToList();
            }
            var filteredProducts = allProducts.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Product, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Name : n.Name_en);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProducts = sortDirection == "asc" ? filteredProducts.OrderBy(orderingFunction) : filteredProducts.OrderByDescending(orderingFunction);

            var result = filteredProducts.Select(Product => new[]
            {
                Product.Id.ToString(CultureInfo.InvariantCulture), Product.Name, Product.Name_en,
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

        [HttpGet]
        public ActionResult LoadAllProductVariants(int id, JQueryDataTableParamModel param)
        {
            var product = Db.Products.SingleOrDefault(v => v.Id == id);
            var allVariants = product.ProductVariants.ToList();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                allVariants = allVariants
                         .Where(c => c.VariantCode.Contains(param.sSearch)
                                     ||
                          c.VariantName.Contains(param.sSearch)
                          ||
                          c.BrandName.Contains(param.sSearch)
                          ||
                          c.Origin.Contains(param.sSearch)).ToList();
            }
            var filteredProducts = allVariants.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ProductVariant, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.VariantCode :
                                                                sortColumnIndex == 2 ? n.VariantName :
                                                                sortColumnIndex == 3 ? n.Price.ToString() :
                                                                sortColumnIndex == 4 ? n.OnHand.ToString() :
                                                                sortColumnIndex == 5 ? n.BrandName :
                                                                sortColumnIndex == 6 ? n.Origin
                                                                : n.VariantName);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProducts = sortDirection == "asc" ? filteredProducts.OrderBy(orderingFunction) : filteredProducts.OrderByDescending(orderingFunction);

            var result = filteredProducts.Select(ProductVariant => new[]
            {
                ProductVariant.Id.ToString(CultureInfo.InvariantCulture), ProductVariant.VariantName, ProductVariant.VariantCode,
                ProductVariant.Price.ToString("N0", new CultureInfo("vi-VN")), ProductVariant.OnHand.ToString("N0"), ProductVariant.BrandName, ProductVariant.Origin
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allVariants.Count(),
                iTotalDisplayRecords = allVariants.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveProducts(int id)
        {
            var result = new AjaxSimpleResultModel();
            var Product = Db.Products.SingleOrDefault(c => c.Id == id);
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
