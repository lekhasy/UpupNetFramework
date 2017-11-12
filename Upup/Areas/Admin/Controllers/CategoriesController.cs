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
    public class CategoriesController : AdminControllerBase
    {
        [HttpGet]
        public ActionResult ManageCategories(int? id)
        {
            var allCategories = Mapper.Map<List<Category>, List<CategoryModel>>(Db.Categories.ToList());
            var parentCategories = allCategories.Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            parentCategories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục cha",
                Value = string.Empty,
                Selected = true
            });
            var productCategory = new CategoryModel {
                AllCategoriesLevel = allCategories,
                ParentCategories = parentCategories
            };
            if (id == null) return View(productCategory);
            var result = Db.Categories.Find(id);
            if (result != null)
            {
                productCategory = Mapper.Map<Category, CategoryModel>(result);
                productCategory.ParentCategories = parentCategories;
                productCategory.AllCategoriesLevel = allCategories;
                if (productCategory.ParentCategory != null)
                {
                    productCategory.ParentCategory_Id = Convert.ToInt32(result.ParentCategory.Id);
                }
                return View(productCategory);
            }
            ModelState.AddModelError("ProgressError", "Danh mục bạn chọn đã bị xóa hoặc không tồn tại");
            return View(productCategory);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManageCategories(CategoryModel model)
        {
            var allCategories = Mapper.Map<List<Category>, List<CategoryModel>>(Db.Categories.ToList());
            var imgUrl = !string.IsNullOrEmpty(model.ImageUrl) ? model.ImageUrl : string.Empty;
            imgUrl = imgUrl.EndsWith(",") ? imgUrl.Remove(imgUrl.Length - 1, 1) : imgUrl;
            var keywords = model.MetaKeyword;
            if (!string.IsNullOrEmpty(keywords))
            {
                keywords = keywords.EndsWith(",")
                    ? Regex.Replace(model.MetaKeyword, ",{2,}", ",").Trim(',')
                    : model.MetaKeyword;
            }
            var keywords2 = model.MetaKeyword_en;
            if (!string.IsNullOrEmpty(keywords2))
            {
                keywords2 = keywords2.EndsWith(",")
                    ? Regex.Replace(model.MetaKeyword_en, ",{2,}", ",").Trim(',')
                    : model.MetaKeyword_en;
            }
            var parentCategory = Db.Categories.Find(model.ParentCategory_Id);
            //if (parentCategory == null)
            //    throw new Exception("Danh mục cha có thể đã bị xóa!");
            if (model.Id == 0)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Name_en = model.Name_en,
                    Description = model.Description,
                    Description_en = model.Description_en,
                    ParentCategory = parentCategory,
                    MetaDescription = model.MetaDescription,
                    MetaKeyword = keywords,
                    MetaDescription_en = model.MetaDescription_en,
                    MetaKeyword_en = keywords,
                    ImageUrl = imgUrl,
                };
                try
                {
                    Db.Categories.Add(category);
                    Db.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 danh mục mới !");
            }
            else
            {
                var category = Db.Categories.Find(model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                    category.Name_en = model.Name_en;
                    category.ImageUrl = imgUrl;
                    category.Description = model.Description;
                    category.Description_en = model.Description_en;
                    category.ParentCategory = parentCategory;
                    category.MetaDescription = model.MetaDescription;
                    category.MetaKeyword = keywords;
                    category.MetaDescription_en = model.MetaDescription_en;
                    category.MetaKeyword_en = keywords2;
                    try
                    {
                        Db.Entry(category).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho danh mục !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "Danh mục bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            var parentCategories = Db.Categories.ToList().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            parentCategories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục cha",
                Value = string.Empty,
                Selected = true
            });
            model.ParentCategories = parentCategories;
            model.AllCategoriesLevel = allCategories;
            ViewData["CategoryImgUrl"] = "/Images/Category/" + imgUrl;
            return View(model);
        }

        [HttpGet]

        public ActionResult LoadAllCategories(JQueryDataTableParamModel param)
        {
            var allCategories = Db.Categories.ToList();
            List<Category> afterFound = new List<Category>();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                afterFound = Db.Categories.ToList()
                         .Where(c => c.Name.Contains(param.sSearch)
                                     ||
                          c.Name_en.Contains(param.sSearch)
                                     ||
                          c.Description.Contains(param.sSearch)).ToList();
            }
            var filteredCategories = allCategories.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Category, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Name :
                                                                sortColumnIndex == 2 ? n.Name_en : n.Description);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredCategories = sortDirection == "asc" ? filteredCategories.OrderBy(orderingFunction) : filteredCategories.OrderByDescending(orderingFunction);

            var result = filteredCategories.Select(Category => new[]
            {
                Category.Id.ToString(CultureInfo.InvariantCulture), Category.Name, Category.Name_en, Category.Description,
                Category.ImageUrl, Category.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allCategories.Count(),
                iTotalDisplayRecords = allCategories.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveCategories(int id)
        {
            var result = new AjaxSimpleResultModel();
            var category = Db.Categories.ToList().SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "Danh mục bạn chọn đã được xóa thành công !";
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
                result.Message = "Danh mục bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(Db.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Name_en,Descripton,ImageUrl")] Category category)
        {
            if (ModelState.IsValid)
            {
                Db.Categories.Add(category);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Name_en,Descripton,ImageUrl")] Category category)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(category).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Category category = Db.Categories.Find(id);
            Db.Categories.Remove(category);
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
