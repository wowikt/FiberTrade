using Abp.Application.Services;
using FifteenGame.Game.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game
{
    public interface IGameAppService : IApplicationService
    {
        GameField GameField { get; }
    }
}
