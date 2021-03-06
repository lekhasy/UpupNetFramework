﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.ViewModels;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class ProductCategoryController : UpupControllerBase
    {
        // GET: ProductCategory
        public ActionResult Index(long? id)
        {
            var vm = new ProductCategoryViewModel
            {
                Categories = Db.Categories.Where(c => c.ParentCategory == null).ToList(),
                CurrentCategory = Db.Categories.FirstOrDefault(c => c.Id == id)
            };
            return View(vm);
        }
    }
}