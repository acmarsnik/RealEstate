using MongoDB.Driver;
using RealEstate.App_Start;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        public RealEstateContext Context = new RealEstateContext();

        public async Task<JsonResult> Index()
        {
            IAsyncCursor<string> collectionNames = await Context.Database.ListCollectionNamesAsync();
            List<string> collectionNamesList = collectionNames.ToList();
            JsonResult jsonCollectionNamesList = Json(collectionNamesList, JsonRequestBehavior.AllowGet);
            return jsonCollectionNamesList;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}