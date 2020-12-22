using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Dto
{
    public class GameField
    {
        public const int RowCount = 4;
        public const int ColumnCount = 4;

        private int[,] _field = new int[RowCount, ColumnCount];

        public int this[int row, int column]
        {
            get => _field[row, column];
            set => _field[row, column] = value;
        }

        public int EmptyCellRow { get; set; }

        public int EmptyCellColumn { get; set; }

        public int MoveCount { get; set; }

        public IEnumerable<int> GetState()
        {
            var result = new List<int>();

            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    result.Add(_field[row, column]);
                }
            }

            return result;
        }

        public bool SetState(IEnumerable<int> state)
        {
            var stateList = state.ToList();
            if (state.Count() != RowCount * ColumnCount)
            {
                return false;
            }

            // TODO: Проверить, что в исходном массиве содержатся различные значения от 0 до 15

            int i = 0;
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    _field[row, column] = stateList[i];
                    if (stateList[i] == 0)
                    {
                        EmptyCellRow = row;
                        EmptyCellColumn = column;
                    }

                    i++;
                }
            }

            return true;
        }
    }
}
