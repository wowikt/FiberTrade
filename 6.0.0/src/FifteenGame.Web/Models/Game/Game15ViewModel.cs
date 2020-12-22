using FifteenGame.Common.Enums;
using FifteenGame.Game.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifteenGame.Web.Models.Game
{
    public class Game15ViewModel
    {
        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public ButtonViewModel[,] Buttons { get; set; }

        public void BuildFromGameField(GameField field)
        {
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

                    newButton.IsVisible = (row != field.EmptyCellRow) || (col != field.EmptyCellColumn);
                    newButton.MoveDirection = MoveDirection.None;
                    if (row == field.EmptyCellRow && col == field.EmptyCellColumn - 1)
                    {
                        newButton.MoveDirection = MoveDirection.Right;
                    }
                    else if (row == field.EmptyCellRow && col == field.EmptyCellColumn + 1)
                    {
                        newButton.MoveDirection = MoveDirection.Left;
                    }
                    else if (row == field.EmptyCellRow - 1 && col == field.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Down;
                    }
                    else if (row == field.EmptyCellRow + 1 && col == field.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Up;
                    }

                    Buttons[row, col] = newButton;
                }
            }
        }
    }
}