using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplier.Business.Models
{
    public class Matrix
    {
        private double[,] _matrix;

        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        public int RowCount => _matrix.GetLength(0);

        public int ColumnCount => _matrix.GetLength(1);

        public Matrix(int rowCount, int columnCount)
        {
            _matrix = new double[rowCount, columnCount];
        }
    }
}
