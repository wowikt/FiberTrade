using FifteenGame.Common.DataDto;
using FifteenGame.Common.Repositories;
using FifteenGameDbFirstRepository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameDbFirstRepository.Repositories
{
    public class CurrentGameRepository : ICurrentGameRepository
    {
        public GameStateDto GetCurrentGameState(int userId)
        {
            using (var db = new FifteenGameDbFirstEntities())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.UserId == userId);
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
            using (var db = new FifteenGameDbFirstEntities())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.UserId == userId);
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
            using (var db = new FifteenGameDbFirstEntities())
            {
                var currentGame = db.CurrentGames.FirstOrDefault(cg => cg.UserId == userId);
                if (currentGame == null)
                {
                    currentGame = new CurrentGame
                    {
                        UserId = userId,
                        MoveCount = state.MoveCount,
                        GameStartTime = state.GameStartTime,
                    };

                    db.CurrentGames.Add(currentGame);
                }
                else
                {
                    currentGame.MoveCount = state.MoveCount;
                    currentGame.GameStartTime = state.GameStartTime;
                }

                while (currentGame.CurrentGameCells.Any())
                {
                    db.CurrentGameCells.Remove(currentGame.CurrentGameCells.First());
                }

                int i = 1;
                foreach(var cell in state.State)
                {
                    currentGame.CurrentGameCells.Add(new CurrentGameCell
                    {
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
