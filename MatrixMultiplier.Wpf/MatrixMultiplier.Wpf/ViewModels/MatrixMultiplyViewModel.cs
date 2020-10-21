using MatrixMultiplier.Business.Models;
using MatrixMultiplier.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplier.Wpf.ViewModels
{
    public class MatrixMultiplyViewModel
    {
        public int ARowCount { get; set; }

        public int AColumnCount { get; set; }

        public int BColumnCount { get; set; }

        public ObservableCollection<MatrixRowViewModel> AMatrixData { get; } = new ObservableCollection<MatrixRowViewModel>();

        public ObservableCollection<MatrixRowViewModel> BMatrixData { get; } = new ObservableCollection<MatrixRowViewModel>();

        public ObservableCollection<MatrixRowViewModel> ResultMatrixData { get; } = new ObservableCollection<MatrixRowViewModel>();

        public void UpdateMatrixSizes(int aRowCount, int aColumnCount, int bColumnCount, bool fillRandom = false)
        {
            AMatrixData.Clear();
            for (int i = 0; i < aRowCount; i++)
            {
                AMatrixData.Add(new MatrixRowViewModel(aColumnCount, fillRandom) { RowIndex = i });
            }

            BMatrixData.Clear();
            for (int i = 0; i < aColumnCount; i++)
            {
                BMatrixData.Add(new MatrixRowViewModel(bColumnCount, fillRandom) { RowIndex = i });
            }

            ResultMatrixData.Clear();
            for (int i = 0; i < aRowCount; i++)
            {
                ResultMatrixData.Add(new MatrixRowViewModel(bColumnCount, fillRandom) { RowIndex = i });
            }
        }

        public void Multiply()
        {
            var service = new MatrixMultiplierService();
            service.AMatrix = ConvertToBusinessModel(AMatrixData, ARowCount, AColumnCount);
            service.BMatrix = ConvertToBusinessModel(BMatrixData, AColumnCount, BColumnCount);
            var result = service.Multiply();
            FillFromBusinessModel(ResultMatrixData, result);
        }

        private Matrix ConvertToBusinessModel(ObservableCollection<MatrixRowViewModel> viewModel, int rowCount, int columnCount)
        {
            var result = new Matrix(rowCount, columnCount);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    result[i, j] = viewModel[i][j];
                }
            }

            return result;
        }

        private void FillFromBusinessModel(ObservableCollection<MatrixRowViewModel> viewModel, Matrix businessModel)
        {
            viewModel.Clear();

            for (int i = 0; i < businessModel.RowCount; i++)
            {
                var newRow = new MatrixRowViewModel(businessModel.ColumnCount, false) { RowIndex = i };
                for (int j = 0; j < businessModel.ColumnCount; j++)
                {
                    newRow[j] = businessModel[i, j];
                }

                viewModel.Add(newRow);
            }
        }
    }
}
