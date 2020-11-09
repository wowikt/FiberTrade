using FifteenGame.Business.Services;
using FifteenGameWebApi.Models;
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

        public IEnumerable<int> Get()
        {
            _service.Initialize();
            _service.Shuffle();
            return _service.GameField.GetState();
        }

        public IEnumerable<int> Post([FromBody]MoveInputModel move)
        {
            _service.Initialize();
            _service.GameField.SetState(move.State);
            _service.MakeMove(move.Direction);
            return _service.GameField.GetState();
        }
    }
}
