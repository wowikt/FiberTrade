using FifteenGame.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FifteenGameMvvm.Wpf.ViewModels
{
    public class ButtonViewModel : INotifyPropertyChanged
    {
        private int _row;

        private int _column;

        private int _value;

        private bool _isVisible;

        private MoveDirection _moveDirection;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Row
        {
            get => _row;
            set
            {
                _row = value;
                OnPropertyChanged("Row");
            }
        }

        public int Column
        {
            get => _column;
            set
            {
                _column = value;
                OnPropertyChanged("Column");
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Text");
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged("Visibility");
            }
        }

        public MoveDirection MoveDirection
        {
            get => _moveDirection;
            set
            {
                _moveDirection = value;
                OnPropertyChanged("MoveDirection");
                OnPropertyChanged("IsEnabled");
            }
        }

        public string Text => Value.ToString();

        public Visibility Visibility => IsVisible ? Visibility.Visible : Visibility.Collapsed;

        public bool IsEnabled => MoveDirection != MoveDirection.None;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
