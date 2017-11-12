using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Controllers
{
    [AllowAnonymous]
    public class ProductController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index(long? id)
        {
            var product = Db.Products.Find(id);
            return View(product);
        }

        //public ActionResult Search(string term)
        //{
            
        //}

        //private async Task<IEnumerable<Product>> SearchforProductAsync(string term)
        //{
        //    var products = await this.Db.Products.Where(p => p.Code == term).ToListAsync();

        //    if (!products.Any())
        //    {
               
        //    }

        //}

    }
}