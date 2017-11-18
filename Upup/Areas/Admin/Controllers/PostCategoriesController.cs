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
    public class PostCategoriesController : AdminControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PostCategories
        public ActionResult Index()
        {
            return View(db.PostCategories.ToList());
        }

        [HttpGet]
        public ActionResult ManagePostCategories(int? id)
        {
            var allPostCategories = Mapper.Map<List<PostCategory>, List<PostCategoryModel>>(Db.PostCategories.ToList());
            var parentCategories = allPostCategories.Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            parentCategories.Insert(0, new SelectListItem
            {
                Text = "Chọn Danh mục bài viết cha",
                Value = string.Empty,
                Selected = true
            });
            var postCategory = new PostCategoryModel {
                ParentCategories = parentCategories,
                AllPostCategoriesLevel = allPostCategories
            };
            if (id == null) return View(postCategory);
            var result = db.PostCategories.Find(id);
            if (result != null)
            {
                postCategory = Mapper.Map<PostCategory, PostCategoryModel>(result);
                postCategory.ParentCategories = parentCategories;
                postCategory.AllPostCategoriesLevel = allPostCategories;
                if (postCategory.ParentCategory != null)
                {
                    postCategory.PostParentCategory_Id = Convert.ToInt32(result.ParentCategory.Id);
                }
                return View(postCategory);
            }
            ModelState.AddModelError("ProgressError", "Danh mục bài viết bạn chọn đã bị xóa hoặc không tồn tại");
            return View(postCategory);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManagePostCategories(PostCategoryModel model)
        {
            var allPostCategories = Mapper.Map<List<PostCategory>, List<PostCategoryModel>>(Db.PostCategories.ToList());
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
            var parentCategory = db.PostCategories.Find(model.PostParentCategory_Id);
            //if (parentCategory == null)
            //    throw new Exception("Danh mục bài viết cha có thể đã bị xóa!");
            if (model.Id == 0)
            {
                var category = new PostCategory
                {
                    Name = model.Name,
                    Name_en = model.Name_en,
                    Description = model.Description,
                    Description_en = model.Description_en,
                    ParentCategory = parentCategory,
                    MetaDescription = model.MetaDescription,
                    MetaKeyword = keywords,
                    MetaDescription_en = model.MetaDescription_en,
                    MetaKeyword_en = keywords2
                };
                try
                {
                    db.PostCategories.Add(category);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 danh mục bài viết mới !");
            }
            else
            {
                var category = db.PostCategories.Find(model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                    category.Name_en = model.Name_en;
                    category.Description = model.Description;
                    category.Description_en = model.Description_en;
                    category.ParentCategory = parentCategory;
                    category.MetaDescription = model.MetaDescription;
                    category.MetaKeyword = keywords;
                    category.MetaDescription_en = model.MetaDescription_en;
                    category.MetaKeyword_en = keywords2;
                    try
                    {
                        db.Entry(category).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho Danh mục bài viết !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "Danh mục bài viết bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            var parentCategories = db.PostCategories.ToList().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            parentCategories.Insert(0, new SelectListItem
            {
                Text = "Chọn Danh mục bài viết cha",
                Value = string.Empty,
                Selected = true
            });
            model.ParentCategories = parentCategories;
            model.AllPostCategoriesLevel = allPostCategories;
            return View(model);
        }

        [HttpGet]
        public ActionResult LoadAllCategories(JQueryDataTableParamModel param)
        {
            var allCategories = db.PostCategories.Where(c => c.RootCategoryIdentifier == null).ToList();
            List<PostCategory> afterFound = new List<PostCategory>();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                afterFound = db.PostCategories.ToList()
                         .Where(c => c.Name.Contains(param.sSearch)
                                     ||
                          c.Name_en.Contains(param.sSearch)
                                     ||
                          c.Description.Contains(param.sSearch)).ToList();
            }
            var filteredCategories = allCategories.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PostCategory, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Name :
                                                                sortColumnIndex == 2 ? n.Name_en : n.Description);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredCategories = sortDirection == "asc" ? filteredCategories.OrderBy(orderingFunction) : filteredCategories.OrderByDescending(orderingFunction);

            var result = filteredCategories.Select(PostCategory => new[]
            {
                PostCategory.Id.ToString(CultureInfo.InvariantCulture), PostCategory.Name, PostCategory.Name_en, PostCategory.Description, PostCategory.Id.ToString(CultureInfo.InvariantCulture)
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
            var category = db.PostCategories.ToList().SingleOrDefault(c => c.Id == id);
            if (category != null && category.RootCategoryIdentifier == null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "Danh mục bài viết bạn chọn đã được xóa thành công !";
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
                result.Message = "Danh mục bài viết bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/PostCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory != null && postCategory.RootCategoryIdentifier != null) throw new ArgumentException("Can't view root category");
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // GET: Admin/PostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Name_en,Description,Description_en,MetaKeyword,MetaDescription")] PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                db.PostCategories.Add(postCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postCategory);
        }

        // GET: Admin/PostCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory != null && postCategory.RootCategoryIdentifier != null) throw new ArgumentException("Can't edit root category");
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // POST: Admin/PostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Name_en,Description,Description_en,MetaKeyword,MetaDescription")] PostCategory postCategory)
        {
            var post = db.PostCategories.Find(postCategory.Id);
            if (post != null && post.RootCategoryIdentifier != null) throw new ArgumentException("Can't edit root category");
            if (ModelState.IsValid)
            {
                db.Entry(postCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postCategory);
        }

        // GET: Admin/PostCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory != null && postCategory.RootCategoryIdentifier != null) throw new ArgumentException("Can't delete root category");
            if (postCategory == null)
            {
                return HttpNotFound();
            }
            return View(postCategory);
        }

        // POST: Admin/PostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PostCategory postCategory = db.PostCategories.Find(id);
            if (postCategory != null && postCategory.RootCategoryIdentifier != null) throw new ArgumentException("Can't delete root category");
            db.PostCategories.Remove(postCategory);
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
