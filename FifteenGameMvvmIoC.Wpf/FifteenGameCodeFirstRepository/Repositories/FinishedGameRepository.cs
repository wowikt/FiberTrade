using FifteenGame.Common.DataDto;
using FifteenGame.Common.Infrastructure;
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
    public class FinishedGameRepository : IFinishedGameRepository
    {
        public IEnumerable<FinishedGameDto> GetAll()
        {
            using (var db = new FifteenGameModel())
            {
                return GameMapper.Instance.Map<IEnumerable<FinishedGameDto>>(db.FinishedGames);
            }
        }

        public void Save(FinishedGameDto finishedGame)
        {
            using (var db = new FifteenGameModel())
            {
                var finishedGameEntity = GameMapper.Instance.Map<FinishedGame>(finishedGame);
                finishedGameEntity.User = db.Users.First(u => u.Id == finishedGame.UserId);
                db.FinishedGames.Add(finishedGameEntity);
                db.SaveChanges();
            }
        }
    }
}
