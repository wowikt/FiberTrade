using FifteenGame.Common.Enums;
using FifteenGame.Common.Interfaces;
using FifteenGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameIoc.Wpf.ViewModels
{
    public class GameViewModel
    {
        private IGameService _service;

        public ObservableCollection<ButtonViewModel> Buttons { get; } = new ObservableCollection<ButtonViewModel>();

        public GameViewModel(IGameService service)
        {
            _service = service;
            _service.StartNewGame();
            BuildViewModel();
        }

        public void MakeMove(MoveDirection direction)
        {
            if (direction == MoveDirection.None)
            {
                return;
            }

            _service.MakeMove(direction);
            UpdateViewModel();
        }

        private void BuildViewModel()
        {
            Buttons.Clear();
            var gameField = _service.GetField();
            for (int i = 0; i < GameField.RowCount; i++)
            {
                for (int j = 0; j < GameField.ColumnCount; j++)
                {
                    var newButton = new ButtonViewModel
                    {
                        Row = i,
                        Column = j,
                        Value = gameField[i, j],
                    };

                    newButton.IsVisible = (i != gameField.EmptyCellRow) || (j != gameField.EmptyCellColumn);
                    newButton.MoveDirection = MoveDirection.None;
                    if (i == gameField.EmptyCellRow && j == gameField.EmptyCellColumn - 1)
                    {
                        newButton.MoveDirection = MoveDirection.Right;
                    }
                    else if (i == gameField.EmptyCellRow && j == gameField.EmptyCellColumn + 1)
                    {
                        newButton.MoveDirection = MoveDirection.Left;
                    }
                    else if (i == gameField.EmptyCellRow - 1 && j == gameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Down;
                    }
                    else if (i == gameField.EmptyCellRow + 1 && j == gameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Up;
                    }

                    Buttons.Add(newButton);
                }
            }
        }

        private void UpdateViewModel()
        {
            var gameField = _service.GetField();
            foreach (var button in Buttons)
            {
                int row = button.Row;
                int column = button.Column;
                button.Value = gameField[row, column];
                button.IsVisible = (row != gameField.EmptyCellRow) || (column != gameField.EmptyCellColumn);
                button.MoveDirection = MoveDirection.None;
                if (row == gameField.EmptyCellRow && column == gameField.EmptyCellColumn - 1)
                {
                    button.MoveDirection = MoveDirection.Right;
                }
                else if (row == gameField.EmptyCellRow && column == gameField.EmptyCellColumn + 1)
                {
                    button.MoveDirection = MoveDirection.Left;
                }
                else if (row == gameField.EmptyCellRow - 1 && column == gameField.EmptyCellColumn)
                {
                    button.MoveDirection = MoveDirection.Down;
                }
                else if (row == gameField.EmptyCellRow + 1 && column == gameField.EmptyCellColumn)
                {
                    button.MoveDirection = MoveDirection.Up;
                }
            }
        }
    }
}
