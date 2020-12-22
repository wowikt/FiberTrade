using FifteenGame.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Repositories
{
    public interface ICurrentGameRepository
    {
        CurrentGame GetByUserId(int userId);

        void Save(CurrentGame currentGame);

        void RemoveCurrentGame(int userId);
    }
}
