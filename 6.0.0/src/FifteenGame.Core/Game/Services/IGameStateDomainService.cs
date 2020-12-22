using Abp.Domain.Services;
using FifteenGame.Game.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Services
{
    public interface IGameStateDomainService : IDomainService
    {
        GameField GetCurrentGame(int userId);

        void SaveCurrentGame(int userId, GameField gameField);
    }
}
