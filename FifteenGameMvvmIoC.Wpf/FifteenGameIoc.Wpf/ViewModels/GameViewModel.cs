using FifteenGame.Common.Enums;
using FifteenGame.Common.Interfaces;
using FifteenGame.Common.Models;
using FifteenGame.FileService.Models;
using FifteenGame.FileService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FifteenGameIoc.Wpf.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private IGameService _service;
        private int _moveCount = 0;
        private User _user;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ButtonViewModel> Buttons { get; } = new ObservableCollection<ButtonViewModel>();

        public Window View { get; set; }

        public User User 
        { 
            get => _user; 
            set
            {
                _user = value;
                if (_user != null)
                {
                    View.IsEnabled = true;
                    _service.StartNewGame();
                    UpdateViewModel();
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Title => $"Игра 15: [{User?.UserName ?? ""}]";

        public GameViewModel(IGameService service)
        {
            _service = service;
            _service.StartNewGame();
            _moveCount = 0;
            BuildViewModel();
        }

        public void CloseView()
        {
            View.Close();
        }

        public void MakeMove(MoveDirection direction)
        {
            if (direction == MoveDirection.None)
            {
                return;
            }

            _service.MakeMove(direction);
            _moveCount++;
            UpdateViewModel();
        }

        public void SaveToFile(string fileName)
        {
            var saveModel = new SaveGameStateModel
            {
                State = _service.GetField().GetState().ToList(),
                GameTime = DateTime.Now.TimeOfDay,
                MoveCount= _moveCount,
            };

            if (Path.GetExtension(fileName).ToUpper()[1] == 'J')
            {
                new JsonFileService().SaveToFile(saveModel, fileName);
            }
            else
            {
                new XmlFileService().SaveToFile(saveModel, fileName);
            }
        }

        public void ReadFromFile(string fileName)
        {
            SaveGameStateModel openModel;
            if (Path.GetExtension(fileName).ToUpper()[1] == 'J')
            {
                openModel = new JsonFileService().ReadFromFile<SaveGameStateModel>(fileName);
            }
            else
            {
                openModel = new XmlFileService().ReadFromFile<SaveGameStateModel>(fileName);
            }

            _service.GetField().SetState(openModel.State);
            _moveCount = openModel.MoveCount;
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
