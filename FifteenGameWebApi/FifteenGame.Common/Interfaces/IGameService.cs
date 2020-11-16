using FifteenGame.Common.Enums;
using FifteenGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Interfaces
{
    public interface IGameService
    {
        void StartNewGame();

        void MakeMove(MoveDirection direction);

        GameField GetField();
    }
}
