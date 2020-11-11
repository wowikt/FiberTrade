using FifteenGame.Common.Dto;
using FifteenGame.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.ServerProxy.Services
{
    public class GameServerProxy
    {
        private readonly string _appPath = ConfigurationManager.AppSettings["AppPath"];

        public IEnumerable<int> State { get; private set; }

        public void Initialize()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(new Uri(_appPath + "/api/game15")).Result;
                var reply = JsonConvert.DeserializeObject<GameStateDto>(result);
                State = reply.State.ToList();
            }
        }

        public void MakeMove(MoveDirection direction)
        {
            using (var client = new HttpClient())
            {
                var response = client
                    .PostAsJsonAsync(new Uri(_appPath + "/api/game15"), new MoveInputDto { Direction = direction, State = State })
                    .Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var reply = JsonConvert.DeserializeObject<GameStateDto>(result);
                State = reply.State.ToList();
            }
        }
    }
}
