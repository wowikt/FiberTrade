using Abp.Web.Mvc.Authorization;
using FifteenGame.Common.Enums;
using FifteenGame.Game;
using FifteenGame.Web.Models.Game;
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
        private readonly IGameAppService _gameAppService;

        public FifteenGameController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

        // GET: FifteenGame
        public ActionResult Index()
        {
            var viewModel = new Game15ViewModel();
            viewModel.BuildFromGameField(_gameAppService.GetCurrentGame());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult MakeMove(MoveDirection direction)
        {
            var viewModel = new Game15ViewModel();
            viewModel.BuildFromGameField(_gameAppService.MakeMove(direction));
            return View("Index", viewModel);
        }
    }
}