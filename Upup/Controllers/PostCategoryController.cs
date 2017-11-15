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
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<PostCategory>,List<PostCategoryViewModel>>(Db.PostCategories.ToList());
            return View(categories);
        }
    }
}