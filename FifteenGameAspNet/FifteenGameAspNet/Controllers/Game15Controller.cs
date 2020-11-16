using FifteenGame.Business.Services;
using FifteenGame.Common.Enums;
using FifteenGameAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifteenGameAspNet.Controllers
{
    public class Game15Controller : Controller
    {
        private GameService Service
        {
            get
            {
                if (Session["Service"] == null)
                {
                    var service = new GameService();
                    service.Initialize();
                    service.Shuffle();
                    Session["Service"] = service;
                    return service;
                }

                return (GameService)Session["Service"];
            }
        }

        public Game15Controller()
        {
        }

        // GET: Game15
        public ActionResult Index()
        {
            var viewModel = new Game15ViewModel();
            viewModel.BuildFromService(Service);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(MoveDirection direction)
        {
            Service.MakeMove(direction);
            return new JsonResult();
        }

        [HttpPost]
        public ActionResult MakeMove(MoveDirection direction)
        {
            Service.MakeMove(direction);
            var viewModel = new Game15ViewModel();
            viewModel.BuildFromService(Service);
            return View("Index", viewModel);
        }
    }
}