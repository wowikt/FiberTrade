using Abp.Domain.Services;
using FifteenGame.Game.Dto;
using FifteenGame.Game.Entities;
using FifteenGame.Game.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Services
{
    public class GameStateDomainService : DomainService, IGameStateDomainService
    {
        private readonly ICurrentGameRepository _currentGameRepository;

        public GameStateDomainService(ICurrentGameRepository currentGameRepository)
        {
            _currentGameRepository = currentGameRepository;
        }

        public GameField GetCurrentGame(int userId)
        {
            var currentGame = _currentGameRepository.GetByUserId(userId);
            var result = new GameField { MoveCount = currentGame.MoveCount };
            result.SetState(currentGame.CurrentGameCells.Select((val, idx) => new { Index = idx, Value = val }).OrderBy(c => c.Index).Select(c => c.Value.CellValue));
            return result;
        }

        public void SaveCurrentGame(int userId, GameField gameField)
        {
            var currentGame = new CurrentGame
            {
                MoveCount = gameField.MoveCount,
                CurrentGameCells = gameField.GetState().Select((val, idx) => new CurrentGameCell { CellIndex = idx, CellValue = val }).ToList(),
                User = new Authorization.Users.User { Id = userId }
            };
            _currentGameRepository.Save(currentGame);
        }
    }
}
