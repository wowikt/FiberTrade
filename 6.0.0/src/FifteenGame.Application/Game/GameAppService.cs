using FifteenGame.Common.Enums;
using FifteenGame.Game.Dto;
using FifteenGame.Game.Repositories;
using FifteenGame.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game
{
    public class GameAppService : IGameAppService
    {
        private readonly IGameStateDomainService _gameStateDomainService;

        private readonly ICurrentGameRepository _currentGameRepository;

        public GameField GameField { get; private set; } = new GameField();

        public int MoveCount => GameField.MoveCount;

        public bool IsGameFinished { get; private set; }

        public GameAppService(IGameStateDomainService gameStateDomainService)
        {
            _gameStateDomainService = gameStateDomainService;
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

        public void MakeMove(int userId, MoveDirection direction)
        {
            var gameState = _gameStateDomainService.GetCurrentGame(userId);
            if (gameState != null)
            {
                GameField = gameState;
                MakeMove(direction);

                if (IsGameFinished)
                {
                    _currentGameRepository.RemoveCurrentGame(userId);
                    //_finishedGameService.Create(new FinishedGame
                    //{
                    //    GameFinishDate = DateTime.Now,
                    //    UserId = userId,
                    //    MoveCount = _moveCount,
                    //});
                }
                else
                {
                    _gameStateDomainService.SaveCurrentGame(userId, GameField);
                }
            }
            else
            {
                StartNewGame(userId);
            }
        }

        private void MakeMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    if (GameField.EmptyCellColumn < GameField.ColumnCount - 1)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn + 1];
                        GameField.EmptyCellColumn++;
                        GameField.MoveCount++;
                    }

                    break;
                case MoveDirection.Right:
                    if (GameField.EmptyCellColumn > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn - 1];
                        GameField.EmptyCellColumn--;
                        GameField.MoveCount++;
                    }

                    break;
                case MoveDirection.Up:
                    if (GameField.EmptyCellRow < GameField.RowCount - 1)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow + 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow++;
                        GameField.MoveCount++;
                    }

                    break;
                case MoveDirection.Down:
                    if (GameField.EmptyCellRow > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow - 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow--;
                        GameField.MoveCount++;
                    }

                    break;
            }

            GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = 0;
            IsGameFinished = GameField.GetState().Select((val, idx) => new { Idx = idx, Val = val }).All(p => p.Val == p.Idx + 1 || p.Val == 0);
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

            GameField.MoveCount = 0;
        }

        public void StartNewGame(int userId)
        {
            var gameState = _gameStateDomainService.GetCurrentGame(userId);
            if (gameState != null)
            {
                GameField = gameState;
            }
            else
            {
                Initialize();
                Shuffle();
                _gameStateDomainService.SaveCurrentGame(userId, GameField);
            }
        }

        public GameField GetField()
        {
            return GameField;
        }
    }
}
