using BuyCalculation.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyCalculation.Wpf.ViewModels
{
    public class CalculationViewModelItem : INotifyPropertyChanged
    {
        private double _cost;

        public string GoodsName { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public double Cost 
        { 
            get => _cost; 
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BuyModel ToBusinessModel()
        {
            return new BuyModel
            {
                GoodsName = GoodsName,
                Price = Price,
                Amount = Amount,
            };
        }

        public static CalculationViewModelItem FromBusinessModel(BuyModel model)
        {
            return new CalculationViewModelItem
            {
                GoodsName = model.GoodsName,
                Price = model.Price,
                Amount = model.Amount,
                Cost = model.Cost
            };
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
