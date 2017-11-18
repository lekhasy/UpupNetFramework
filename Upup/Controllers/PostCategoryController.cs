using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class PostCategoryController : UpupControllerBase
    {
        // GET: PostCategory
        public ActionResult Index(int id)
        {
            var allPostCategories = Db.PostCategories;
            var rootCategories = allPostCategories.Where(cat => cat.ParentCategory == null).ToList();
            var current = allPostCategories.Find(id);
            var root = current;
            while (root.ParentCategory != null)
            {
                root = root.ParentCategory;
            }
            var vm = new PostCategoryViewModel
            {
                RootCategories = rootCategories,
                RootCategory = root,
                CurrentCategory = current
            };
            return View(vm);
        }
    }
}