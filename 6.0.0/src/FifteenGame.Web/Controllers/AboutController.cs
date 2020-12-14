using System.Web.Mvc;

namespace FifteenGame.Web.Controllers
{
    public class AboutController : FifteenGameControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}