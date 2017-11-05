using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}