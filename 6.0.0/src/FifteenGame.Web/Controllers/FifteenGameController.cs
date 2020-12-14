using Abp.Web.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifteenGame.Web.Controllers
{
    [AbpMvcAuthorize]
    public class FifteenGameController : FifteenGameControllerBase
    {
        // GET: FifteenGame
        public ActionResult Index()
        {
            return View();
        }
    }
}