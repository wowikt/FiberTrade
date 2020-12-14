using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace FifteenGame.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FifteenGameControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}