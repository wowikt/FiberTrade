using Abp.Application.Services;
using FifteenGame.Common.Enums;
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
        GameField GetCurrentGame();

        GameField MakeMove(MoveDirection direction);

        GameField GameField { get; }
    }
}
