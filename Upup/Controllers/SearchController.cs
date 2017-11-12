using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Upup.ViewModels;

namespace Upup.Controllers
{
    public class SearchController : UpupControllerBase
    {
        // GET: Search
        public async Task<ActionResult> Index(string term)
        {
            var productids = (await Db.SearchForProduct(term)).ToList().Select(p => p.Id);

            var products = Db.Products.Where(p => productids.Contains(p.Id)).ToList();

            var productContainsCode = products.Where(p => p.Code != null && p.Code.Contains(term));

            products.RemoveAll(p => p.Code != null && p.Code.Contains(term));

            products = productContainsCode.Concat(products).ToList();

            var postsByTitleIds = (await Db.SearchForPostByTitle(term)).ToList().Select(p => p.Id);
            var postByContentIds = (await Db.SearchForPostByContent(term)).ToList().Select(p => p.Id);

            var postsByTitle = Db.Posts.Where(p => postsByTitleIds.Contains(p.Id)).ToList();
            var postByContent = Db.Posts.Where(p => postByContentIds.Contains(p.Id)).ToList();
           
            postByContent.RemoveAll(p => postsByTitle.Any(pt => pt.Id == p.Id));

            var posts = postsByTitle.Concat(postByContent);


            ViewBag.Term = term;

            return View(
                new SearchModels
                {
                    SearchTopicResult = posts.Select(p => new SearchItemModels
                    {
                        Id = p.Id,
                        CategoryId = p.Category.Id,
                        CategoryName = p.Category.Name,
                        Content = p.Content,
                        Title = p.Title,
                        CategoryName_en = p.Category.Name_en,
                        Title_en = p.Title_en,
                        Content_en = p.Content_en
                    }).ToList(),

                    SearchProductResult = products.Select(p => new SearchItemModels
                    {
                        Id = p.Id,
                        Content_en = p.Summary_en,
                        Content = p.Summary,
                        Title_en = p.Name_en,
                        Title = p.Name,
                        Image = p.ImageUrl,
                        CategoryId = p.Category.Id,
                        CategoryName = p.Category.Name,
                        CategoryName_en = p.Category.Name_en
                    }).ToList()
                });
        }
    }
}