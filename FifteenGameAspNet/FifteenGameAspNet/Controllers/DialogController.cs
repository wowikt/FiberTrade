using FifteenGameAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifteenGameAspNet.Controllers
{
    public class DialogController : Controller
    {
        // GET: Dialog
        public ActionResult Index()
        {
            ViewBag.GreetingMessage = "Представьтесь, пожалуйста:";

            return View();
        }

        [HttpPost]
        public ActionResult Index(DialogViewModel model)
        {
            return View("Reply", model);
        }
    }
}