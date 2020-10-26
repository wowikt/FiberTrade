using FifteenGame.Business.Models;
using FifteenGame.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameMvvm.Wpf.ViewModels
{
    public class GameViewModel
    {
        private GameService _service = new GameService();

        public ObservableCollection<ButtonViewModel> Buttons { get; } = new ObservableCollection<ButtonViewModel>();

        public GameViewModel()
        {
            _service.Initialize();
            _service.Shuffle();
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
            for (int i = 0; i < GameField.RowCount; i++)
            {
                for (int j = 0; j < GameField.ColumnCount; j++)
                {
                    var newButton = new ButtonViewModel
                    {
                        Row = i,
                        Column = j,
                        Value = _service.GameField[i, j],
                    };

                    newButton.IsVisible = (i != _service.GameField.EmptyCellRow) || (j != _service.GameField.EmptyCellColumn);
                    newButton.MoveDirection = MoveDirection.None;
                    if (i == _service.GameField.EmptyCellRow && j == _service.GameField.EmptyCellColumn - 1)
                    {
                        newButton.MoveDirection = MoveDirection.Right;
                    }
                    else if (i == _service.GameField.EmptyCellRow && j == _service.GameField.EmptyCellColumn + 1)
                    {
                        newButton.MoveDirection = MoveDirection.Left;
                    }
                    else if (i == _service.GameField.EmptyCellRow - 1 && j == _service.GameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Down;
                    }
                    else if (i == _service.GameField.EmptyCellRow + 1 && j == _service.GameField.EmptyCellColumn)
                    {
                        newButton.MoveDirection = MoveDirection.Up;
                    }

                    Buttons.Add(newButton);
                }
            }
        }

        private void UpdateViewModel()
        {
            foreach (var button in Buttons)
            {
                int row = button.Row;
                int column = button.Column;
                button.Value = _service.GameField[row, column];
                button.IsVisible = (row != _service.GameField.EmptyCellRow) || (column != _service.GameField.EmptyCellColumn);
                button.MoveDirection = MoveDirection.None;
                if (row == _service.GameField.EmptyCellRow && column == _service.GameField.EmptyCellColumn - 1)
                {
                    button.MoveDirection = MoveDirection.Right;
                }
                else if (row == _service.GameField.EmptyCellRow && column == _service.GameField.EmptyCellColumn + 1)
                {
                    button.MoveDirection = MoveDirection.Left;
                }
                else if (row == _service.GameField.EmptyCellRow - 1 && column == _service.GameField.EmptyCellColumn)
                {
                    button.MoveDirection = MoveDirection.Down;
                }
                else if (row == _service.GameField.EmptyCellRow + 1 && column == _service.GameField.EmptyCellColumn)
                {
                    button.MoveDirection = MoveDirection.Up;
                }
            }
        }
    }
}
