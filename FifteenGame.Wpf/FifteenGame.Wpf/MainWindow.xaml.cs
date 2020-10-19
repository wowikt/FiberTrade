using FifteenGame.Business.Models;
using FifteenGame.Business.Services;
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

namespace FifteenGame.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private GameService _gameService = new GameService();

        private void StartMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            _gameService.Initialize();
            _gameService.Shuffle();
            DisplayGameState();
        }

        private void DisplayGameState()
        {
            var buttons = new[]
            {
                Digit1Button,
                Digit2Button,
                Digit3Button,
                Digit4Button,
                Digit5Button,
                Digit6Button,
                Digit7Button,
                Digit8Button,
                Digit9Button,
                Digit10Button,
                Digit11Button,
                Digit12Button,
                Digit13Button,
                Digit14Button,
                Digit15Button,
            };

            var gameField = _gameService.GameField;
            for (int i = 0; i < GameField.RowCount; i++)
            {
                for (int j = 0; j < GameField.ColumnCount; j++)
                {
                    int cellState = gameField[i, j];
                    if (cellState == 0)
                    {
                        continue;
                    }

                    var button = buttons[cellState - 1];
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }
        }
    }
}
