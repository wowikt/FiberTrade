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
            return GetAllIncluding(cg => cg.CurrentGameCells).Where(cg => cg.UserId == userId).FirstOrDefault();
        }

        public void RemoveCurrentGame(int userId)
        {
            var currentGame = GetAll().FirstOrDefault(game => game.UserId == userId);
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
            var currentGame = GetAll().FirstOrDefault(game => game.UserId == cg.UserId);
            if (currentGame == null)
            {
                currentGame = new CurrentGame
                {
                    UserId = cg.UserId,
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

            while (currentGame.CurrentGameCells.Any())
            {
                ((FifteenGameDbContext)GetDbContext()).CurrentGameCells.Remove(currentGame.CurrentGameCells.First());
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
