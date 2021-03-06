﻿using FifteenGame.Common.DataDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Repositories
{
    public interface ICurrentGameRepository
    {
        GameStateDto GetCurrentGameState(int userId);

        void SaveCurrentGameState(int userId, GameStateDto state);

        void RemoveCurrentGame(int userId);
    }
}
