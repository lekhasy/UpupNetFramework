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
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        [HttpGet]
        public ActionResult ManagePosts(int? id)
        {
            var categories = db.PostCategories.ToList().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            categories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục bài viết",
                Value = string.Empty,
                Selected = true
            });
            var Post = new PostModel { PostCategories = categories };
            if (id == null) return View(Post);
            var result = db.Posts.Find(id);
            if (result != null)
            {
                Post = Mapper.Map<Post, PostModel>(result);
                var existpost = db.Posts.Find(Post.Category_id);
                if (existpost == null)
                {
                    result.Category = null;
                    db.Entry(result).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Post.Category_id = Convert.ToInt32(result.Category.Id);
                }
                Post.PostCategories = categories;
                return View(Post);
            }
            ModelState.AddModelError("ProgressError", "Bài viết bạn chọn đã bị xóa hoặc không tồn tại");
            return View(Post);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManagePosts(PostModel model)
        {
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
            var category = db.PostCategories.Find(model.Category_id);
            //if (category == null)
            //    throw new Exception("bài viết cha có thể đã bị xóa!");
            if (model.Id == 0)
            {
                var post = new Post
                {
                    Title = model.Title,
                    Title_en = model.Title_en,
                    Sumary = model.Sumary,
                    Sumary_en = model.Sumary_en,
                    Content = model.Content,
                    Content_en = model.Content_en,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    Category = category,
                    MetaDescription = model.MetaDescription,
                    MetaKeyword = keywords,
                    MetaDescription_en = model.MetaDescription_en,
                    MetaKeyword_en = keywords2
                };
                try
                {
                    db.Posts.Add(post);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 bài viết mới !");
            }
            else
            {
                var post = db.Posts.Find(model.Id);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.Title_en = model.Title_en;
                    post.Sumary = model.Sumary;
                    post.Sumary_en = model.Sumary_en;
                    post.Content = model.Content;
                    post.Content_en = model.Content_en;
                    post.Category = category;
                    post.MetaDescription = model.MetaDescription;
                    post.MetaKeyword = keywords;
                    post.MetaDescription_en = model.MetaDescription_en;
                    post.MetaKeyword_en = keywords2;
                    post.LastModifiedDate = DateTime.Now;
                    try
                    {
                        db.Entry(post).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho bài viết !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "bài viết bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            var categories = db.PostCategories.ToList().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();
            categories.Insert(0, new SelectListItem
            {
                Text = "Chọn danh mục bài viết",
                Value = string.Empty,
                Selected = true
            });
            model.PostCategories = categories;
            return View(model);
        }

        [HttpGet]

        public ActionResult LoadAllPosts(JQueryDataTableParamModel param)
        {
            var allPosts = db.Posts.ToList();
            List<Post> afterFound = new List<Post>();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                afterFound = db.Posts.ToList()
                         .Where(c => c.Title.Contains(param.sSearch)
                                     ||
                          c.Title_en.Contains(param.sSearch)).ToList();
            }
            var filteredPosts = allPosts.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Post, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Title : n.Title_en);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredPosts = sortDirection == "asc" ? filteredPosts.OrderBy(orderingFunction) : filteredPosts.OrderByDescending(orderingFunction);

            var result = filteredPosts.Select(Post => new[]
            {
                Post.Id.ToString(CultureInfo.InvariantCulture), Post.Title, Post.Title_en, Post.Sumary, Post.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allPosts.Count(),
                iTotalDisplayRecords = allPosts.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemovePosts(int id)
        {
            var result = new AjaxSimpleResultModel();
            var post = db.Posts.ToList().SingleOrDefault(c => c.Id == id);
            if (post != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "bài viết bạn chọn đã được xóa thành công !";
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
                result.Message = "bài viết bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Title_en,Content,Content_en,CreatedDate,LastModifiedDate,Sumary,Sumary_en")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Title_en,Content,Content_en,CreatedDate,LastModifiedDate,Sumary,Sumary_en")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
