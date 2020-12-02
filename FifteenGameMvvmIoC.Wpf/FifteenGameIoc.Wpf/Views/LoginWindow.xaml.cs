using FifteenGame.Common.Infrastructure;
using FifteenGameIoc.Wpf.ViewModels;
using Ninject;
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

namespace FifteenGameIoc.Wpf.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel ViewModel => DataContext as LoginViewModel;

        public LoginWindow(LoginViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = PasswordBox.Password;
            if (ViewModel.DoLogin())
            {
                Close();
            }
            else
            {
                MessageBox.Show("Указанный пользователь не найден");
            }    
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ViewModel.DoCancel();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerDialog = NinjectKernel.Instance.Get<RegisterWindow>();
            registerDialog.Owner = Owner;
            registerDialog.ShowInTaskbar = false;
            registerDialog.Show();
            registerDialog.ViewModel.ParentViewModel = ViewModel.ParentViewModel;
            Close();
        }
    }
}
