using FifteenGame.Business.Models;
using FifteenGame.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifteenGameAspNet.Models
{
    public class Game15ViewModel
    {
        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public ButtonViewModel[,] Buttons { get; set; }

        public void BuildFromService(GameService service)
        {
            var field = service.GameField;
            RowCount = GameField.RowCount;
            ColumnCount = GameField.ColumnCount;
            Buttons = new ButtonViewModel[RowCount, ColumnCount];

            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColumnCount; col++)
                {
                    var newButton = new ButtonViewModel
                    {
                        Value = field[row, col]
                    };

                    newButton.IsVisible = (row != service.GameField.EmptyCellRow) || (col != service.GameField.EmptyCellColumn);
                    newButton.MoveDirection = MoveDirection.None;
                    if (row == service.GameField.EmptyCellRow && col == service.GameField.EmptyCellColumn - 1)
                    {
                        newButton.MoveDirection = MoveDirection.Right;
                    }
                    else if (row == service.GameField.EmptyCellRow && col == service.GameField.EmptyCellColumn + 1)
                    {
                        newButton.MoveDirection = MoveDirection.Left;
                    }
                    else if (row == service.GameField.EmptyCellRow - 1 && col == service.GameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Down;
                    }
                    else if (row == service.GameField.EmptyCellRow + 1 && col == service.GameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Up;
                    }

                    Buttons[row, col] = newButton;
                }
            }
        }
    }
}