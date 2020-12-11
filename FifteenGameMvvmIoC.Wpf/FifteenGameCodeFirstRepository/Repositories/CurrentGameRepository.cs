using FifteenGame.Common.DataDto;
using FifteenGame.Common.Repositories;
using FifteenGameCodeFirstRepository.DataAccess;
using FifteenGameCodeFirstRepository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameCodeFirstRepository.Repositories
{
    public class CurrentGameRepository : ICurrentGameRepository
    {
        public GameStateDto GetCurrentGameState(int userId)
        {
            using (var db = new FifteenGameModel())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.User.Id == userId);
                if (currentGame == null)
                {
                    return null;
                }

                var result = new GameStateDto
                {
                    MoveCount = currentGame.MoveCount,
                    GameStartTime = currentGame.GameStartTime,
                    State = currentGame.CurrentGameCells.OrderBy(cgs => cgs.CellIndex).Select(cgs => cgs.CellValue).ToList(),
                };

                return result;
            }
        }

        public void RemoveCurrentGame(int userId)
        {
            using (var db = new FifteenGameModel())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.User.Id == userId);
                if (currentGame == null)
                {
                    return;
                }

                while (currentGame.CurrentGameCells.Any())
                {
                    db.CurrentGameCells.Remove(currentGame.CurrentGameCells.First());
                }

                db.CurrentGames.Remove(currentGame);
                db.SaveChanges();
            }
        }

        public void SaveCurrentGameState(int userId, GameStateDto state)
        {
            using (var db = new FifteenGameModel())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.User.Id == userId);
                if (currentGame == null)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    currentGame = db.CurrentGames.Create();
                    currentGame.User = user;
                    currentGame.MoveCount = state.MoveCount;
                    currentGame.GameStartTime = state.GameStartTime;

                    db.CurrentGames.Add(currentGame);
                }
                else
                {
                    currentGame.MoveCount = state.MoveCount;
                    currentGame.GameStartTime = state.GameStartTime;
                }

                if (currentGame.CurrentGameCells?.Any() ?? false)
                {
                    db.CurrentGameCells.RemoveRange(currentGame.CurrentGameCells);
                }

                int i = 1;
                foreach (var cell in state.State)
                {
                    db.CurrentGameCells.Add(new CurrentGameCell
                    {
                        CurrentGame = currentGame,
                        CellIndex = i,
                        CellValue = cell,
                    });

                    i++;
                }

                db.SaveChanges();
            }
        }
    }
}
