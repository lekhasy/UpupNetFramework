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
            var products = (await Db.SearchForProduct(term)).ToList();

            var productContainsCode = products.Where(p => p.Code.Contains(term));

            products.RemoveAll(p => p.Code.Contains(term));

            products = productContainsCode.Concat(products).ToList();

            var postsByTitle = (await Db.SearchForPostByTitle(term)).ToList();
            var postByContent = (await Db.SearchForPostByContent(term)).ToList();

            postByContent.RemoveAll(p => postsByTitle.Any(pt => pt.Id == p.Id));

            var posts = postsByTitle.Concat(postByContent);


            return View(
                new SearchModels
                {
                    SearchTopicResult = posts.Select(p => new SearchItemModels
                    {

                    }).ToList(),

                    SearchProductResult = products.Select(p => new SearchItemModels
                    {

                    }).ToList()
                });
        }
    }
}