using FifteenGame.Common.DataDto;
using FifteenGame.Common.Infrastructure;
using FifteenGame.Common.Repositories;
using FifteenGameDbFirstRepository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameDbFirstRepository.Repositories
{
    public class FinishedGameRepository : IFinishedGameRepository
    {
        public IEnumerable<FinishedGameDto> GetAll()
        {
            using (var db = new FifteenGameDbFirstEntities())
            {
                return GameMapper.Instance.Map<IEnumerable<FinishedGameDto>>(db.FinishedGames);
            }
        }

        public void Save(FinishedGameDto finishedGame)
        {
            using (var db = new FifteenGameDbFirstEntities())
            {
                db.FinishedGames.Add(GameMapper.Instance.Map<FinishedGame>(finishedGame));
                db.SaveChanges();
            }
        }
    }
}
