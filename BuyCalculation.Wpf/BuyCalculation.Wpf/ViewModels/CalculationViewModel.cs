using BuyCalculation.Business.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyCalculation.Wpf.ViewModels
{
    public class CalculationViewModel : INotifyPropertyChanged
    {
        BuyListModel _model = new BuyListModel();

        private double _totalCost;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CalculationViewModelItem> TableViewModel { get; } = new ObservableCollection<CalculationViewModelItem>();

        public double TotalCost 
        { 
            get => _totalCost; 
            private set
            {
                _totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public CalculationViewModel()
        {
            TableViewModel.Add(new CalculationViewModelItem
            {
                GoodsName = "Молоко",
                Price = 95,
                Amount = 2,
            });

            TableViewModel.Add(new CalculationViewModelItem
            {
                GoodsName = "Хлеб",
                Price = 35,
                Amount = 1,
            });

            TableViewModel.Add(new CalculationViewModelItem
            {
                GoodsName = "Яблоки",
                Price = 100,
                Amount = 1.5,
            });

            Recalculate();
        }

        public void Recalculate()
        {
            //var businessModel = new List<BuyModel>(TableViewModel.Select(vm => vm.ToBusinessModel()));

            //TableViewModel.Clear();
            //foreach (var it in businessModel)
            //{
            //    TableViewModel.Add(CalculationViewModelItem.FromBusinessModel(it));
            //}

            //foreach (var item in TableViewModel)
            //{
            //    var businessModel = item.ToBusinessModel();
            //    item.Cost = businessModel.Cost;
            //}

            _model.BuyList.Clear();
            foreach (var item in TableViewModel)
            {
                var businessModel = item.ToBusinessModel();
                _model.BuyList.Add(businessModel);
                item.Cost = businessModel.Cost;
            }

            TotalCost = _model.TotalCost;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
