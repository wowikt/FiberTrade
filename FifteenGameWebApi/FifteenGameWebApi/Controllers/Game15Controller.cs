using FifteenGame.Business.Services;
using FifteenGame.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FifteenGameWebApi.Controllers
{
    public class Game15Controller : ApiController
    {
        GameService _service = new GameService();

        public GameStateDto Get()
        {
            _service.Initialize();
            _service.Shuffle();
            return new GameStateDto { State = _service.GameField.GetState() };
        }

        public GameStateDto Post([FromBody]MoveInputDto move)
        {
            _service.Initialize();
            _service.GameField.SetState(move.State);
            _service.MakeMove(move.Direction);
            return new GameStateDto { State = _service.GameField.GetState() };
        }
    }
}
