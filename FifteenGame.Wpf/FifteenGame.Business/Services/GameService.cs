using FifteenGame.Common.Enums;
using FifteenGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Business.Services
{
    public class GameService
    {
        public GameField GameField { get; } = new GameField();

        public GameService()
        {
            Initialize();
        }

        public void Initialize()
        {
            int cellValue = 1;
            for (int i = 0; i < GameField.RowCount; i++)
            {
                for (int j = 0; j < GameField.ColumnCount; j++)
                {
                    GameField[i, j] = cellValue++;
                }
            }

            GameField[GameField.RowCount - 1, GameField.ColumnCount - 1] = 0;
            GameField.EmptyCellRow = GameField.RowCount - 1;
            GameField.EmptyCellColumn = GameField.ColumnCount - 1;
        }

        public void MakeMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    if (GameField.EmptyCellColumn < GameField.ColumnCount - 1)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn + 1];
                        GameField.EmptyCellColumn++;
                    }

                    break;
                case MoveDirection.Right:
                    if (GameField.EmptyCellColumn > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn - 1];
                        GameField.EmptyCellColumn--;
                    }

                    break;
                case MoveDirection.Up:
                    if (GameField.EmptyCellRow < GameField.RowCount - 1)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow + 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow++;
                    }

                    break;
                case MoveDirection.Down:
                    if (GameField.EmptyCellRow > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow - 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow--;
                    }

                    break;
            }

            GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = 0;
        }

        public void Shuffle()
        {
            var rnd = new Random();
            const int shuffleCount = 1000;
            for (int i = 0; i < shuffleCount; i++)
            {
                var direction = (MoveDirection)(rnd.Next(4) + 1);
                MakeMove(direction);
            }
        }
    }
}
