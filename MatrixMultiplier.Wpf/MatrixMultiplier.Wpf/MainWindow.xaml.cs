using MatrixMultiplier.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrixMultiplier.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MatrixMultiplyViewModel _viewModel = new MatrixMultiplyViewModel();

        public MainWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void SetSizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ARowCount == 0 || _viewModel.AColumnCount == 0 || _viewModel.BColumnCount == 0)
            {
                return;
            }

            UpdateView();
        }

        private void UpdateView()
        {
            UpdateDataGrid(AMatrixDataGrid, _viewModel.AColumnCount);
            UpdateDataGrid(BMatrixDataGrid, _viewModel.BColumnCount);
            UpdateDataGrid(ResultMatrixDataGrid, _viewModel.BColumnCount);
            _viewModel.UpdateMatrixSizes(_viewModel.ARowCount, _viewModel.AColumnCount, _viewModel.BColumnCount, true);
        }

        private void UpdateDataGrid(DataGrid dataGrid, int columnCount)
        {
            dataGrid.Columns.Clear();

            dataGrid.Columns.Add(new DataGridTextColumn
            {
                IsReadOnly = true,
                Binding = new Binding("RowIndexText"),
            });

            for (int i = 0; i < columnCount; i++)
            {
                var newColumn = new DataGridTextColumn
                {
                    Header = $"[{i}]",
                    Binding = new Binding($"[{i}]") { StringFormat = "F4" },
                };

                dataGrid.Columns.Add(newColumn);
            }
        }

        private void MuliplyButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Multiply();
        }
    }
}
