using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplier.Wpf.ViewModels
{
    public class MatrixRowViewModel
    {
        private double[] _rowItems;

        public int RowIndex { get; set; }

        public string RowIndexText => $"[{RowIndex}]";

        public double this[int index]
        {
            get => _rowItems[index];
            set => _rowItems[index] = value;
        }

        public MatrixRowViewModel(int size, bool fillRandom)
        {
            _rowItems = new double[size];
            if (fillRandom)
            {
                var rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    _rowItems[i] = rnd.NextDouble();
                }
            }
        }
    }
}
