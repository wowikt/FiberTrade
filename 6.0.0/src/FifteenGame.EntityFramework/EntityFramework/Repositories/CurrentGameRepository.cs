using Abp.EntityFramework;
using FifteenGame.Game.Entities;
using FifteenGame.Game.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.EntityFramework.Repositories
{
    public class CurrentGameRepository : FifteenGameRepositoryBase<CurrentGame>, ICurrentGameRepository
    {
        public CurrentGameRepository(IDbContextProvider<FifteenGameDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public CurrentGame GetByUserId(int userId)
        {
            return GetAllIncluding(cg => cg.CurrentGameCells).Where(cg => cg.User.Id == userId).FirstOrDefault();
        }

        public void RemoveCurrentGame(int userId)
        {
            var currentGame = GetAll().FirstOrDefault(game => game.User.Id == game.User.Id);
            if (currentGame == null)
            {
                return;
            }

            while (currentGame.CurrentGameCells.Any())
            {
                ((FifteenGameDbContext)GetDbContext()).CurrentGameCells.Remove(currentGame.CurrentGameCells.First());
            }

            ((FifteenGameDbContext)GetDbContext()).CurrentGames.Remove(currentGame);
        }

        public void Save(CurrentGame cg)
        {
            var currentGame = GetAll().FirstOrDefault(game => game.User.Id == game.User.Id);
            if (currentGame == null)
            {
                var user = ((FifteenGameDbContext)GetDbContext()).Users.FirstOrDefault(u => u.Id == cg.User.Id);
                currentGame = new CurrentGame
                {
                    User = user,
                    MoveCount = cg.MoveCount,
                    GameStartTime = cg.GameStartTime,
                };
                Insert(currentGame);
            }
            else
            {
                currentGame.MoveCount = cg.MoveCount;
                currentGame.GameStartTime = cg.GameStartTime;
            }

            var deletedCells = currentGame.CurrentGameCells;
            if (deletedCells?.Any() ?? false)
            {
                foreach (var cell in deletedCells)
                {
                    ((FifteenGameDbContext)GetDbContext()).CurrentGameCells.Remove(cell);
                }
            }

            int i = 1;
            foreach (var cell in cg.CurrentGameCells)
            {
                ((FifteenGameDbContext)GetDbContext()).CurrentGameCells.Add(new CurrentGameCell
                {
                    CurrentGame = currentGame,
                    CellIndex = cell.CellIndex,
                    CellValue = cell.CellValue,
                });

                i++;
            }
        }
    }
}
