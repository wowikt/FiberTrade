using FifteenGame.Common.DataDto;
using FifteenGame.Common.Enums;
using FifteenGame.Common.Interfaces;
using FifteenGame.Common.Models;
using FifteenGame.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Business.Services
{
    public class GameService : IGameService
    {
        private readonly ICurrentGameRepository _currentGameRepository;
        private readonly IFinishedGameService _finishedGameService;

        private int _moveCount;

        public GameField GameField { get; } = new GameField();

        public int MoveCount => _moveCount;

        public bool IsGameFinished { get; private set; }

        public GameService(ICurrentGameRepository currentGameRepository, IFinishedGameService finishedGameService)
        {
            _currentGameRepository = currentGameRepository;
            _finishedGameService = finishedGameService;
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

        public void MakeMove(int userId, MoveDirection direction)
        {
            var gameState = _currentGameRepository.GetCurrentGameState(userId);
            if (gameState != null)
            {
                GameField.SetState(gameState.State);
                _moveCount = gameState.MoveCount;
                MakeMove(direction);

                if (IsGameFinished)
                {
                    _currentGameRepository.RemoveCurrentGame(userId);
                    _finishedGameService.Create(new FinishedGame
                    {
                        GameFinishDate = DateTime.Now,
                        UserId = userId,
                        MoveCount = _moveCount,
                    });
                }
                else
                {
                    _currentGameRepository.SaveCurrentGameState(userId, new GameStateDto
                    {
                        MoveCount = _moveCount,
                        State = GameField.GetState(),
                    });
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
                        _moveCount++;
                    }

                    break;
                case MoveDirection.Right:
                    if (GameField.EmptyCellColumn > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn - 1];
                        GameField.EmptyCellColumn--;
                        _moveCount++;
                    }

                    break;
                case MoveDirection.Up:
                    if (GameField.EmptyCellRow < GameField.RowCount - 1)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow + 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow++;
                        _moveCount++;
                    }

                    break;
                case MoveDirection.Down:
                    if (GameField.EmptyCellRow > 0)
                    {
                        GameField[GameField.EmptyCellRow, GameField.EmptyCellColumn] = GameField[GameField.EmptyCellRow - 1, GameField.EmptyCellColumn];
                        GameField.EmptyCellRow--;
                        _moveCount++;
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

            _moveCount = 0;
        }

        public void StartNewGame(int userId)
        {
            Initialize();
            var gameState = _currentGameRepository.GetCurrentGameState(userId);
            if (gameState != null)
            {
                GameField.SetState(gameState.State);
                _moveCount = gameState.MoveCount;
            }
            else
            {
                Shuffle();
                _currentGameRepository.SaveCurrentGameState(userId, new GameStateDto
                {
                    MoveCount = 0,
                    State = GameField.GetState(),
                });
            }
        }

        public GameField GetField()
        {
            return GameField;
        }
    }
}
