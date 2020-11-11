using FifteenGame.Common.Enums;
using FifteenGameMvvm.Wpf.ViewModels;
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

namespace FifteenGameMvvm.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameViewModel ViewModel => DataContext as GameViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var direction = button.Tag as MoveDirection?;
            if ((direction ?? MoveDirection.None) != MoveDirection.None)
            {
                ViewModel.MakeMove(direction.Value);
            }
        }
    }
}
