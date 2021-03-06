﻿using FifteenGame.Common.Enums;
using FifteenGame.Common.Infrastructure;
using FifteenGameIoc.Wpf.ViewModels;
using Microsoft.Win32;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameViewModel ViewModel => DataContext as GameViewModel;

        public MainWindow(GameViewModel viewModel)
        {
            DataContext = viewModel;
            viewModel.View = this;
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

        private void SaveGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Файлы игры XML (*.game)|*.game|Файлы игры JSON (*.jgame)|*.jgame|Все файлы (*.*)|*.*" };
            if (dlg.ShowDialog() == true)
            {
                ViewModel.SaveToFile(dlg.FileName);
            }
        }

        private void OpenGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Файлы игры XML (*.game)|*.game|Файлы игры JSON (*.jgame)|*.jgame|Все файлы (*.*)|*.*" };
            if (dlg.ShowDialog() == true)
            {
                ViewModel.ReadFromFile(dlg.FileName);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var loginDialog = NinjectKernel.Instance.Get<LoginWindow>();
            loginDialog.Owner = this;
            loginDialog.ShowInTaskbar = false;
            loginDialog.Show();
            loginDialog.ViewModel.ParentViewModel = ViewModel;
            IsEnabled = false;
        }
    }
}
