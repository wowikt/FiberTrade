using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Business.Models
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
    }
}
