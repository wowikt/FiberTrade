using MatrixMultiplier.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplier.Business.Services
{
    public class MatrixMultiplierService
    {
        public Matrix AMatrix { get; set; }

        public Matrix BMatrix { get; set; }

        public Matrix Multiply()
        {
            int aRowCount = AMatrix.RowCount;
            int aColCount = AMatrix.ColumnCount;

            int bRowCount = BMatrix.RowCount;
            int bColCount = BMatrix.ColumnCount;

            if (aColCount != bRowCount)
            {
                throw new Exception("Matrix sizes are different");
            }

            var result = new Matrix(aRowCount, bColCount);

            for (int i = 0; i < aRowCount; i++)
            {
                for (int j = 0; j < bColCount; j++)
                {
                    double item = 0;
                    for (int k = 0; k < aColCount; k++)
                    {
                        item += AMatrix[i, k] * BMatrix[k, j];
                    }

                    result[i, j] = item;
                }
            }

            return result;
        }
    }
}
