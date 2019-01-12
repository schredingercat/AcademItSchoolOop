using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Minesweeper.Lib;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            var controller = new GuiController();
            DataContext = controller;
            GameField.ItemsSource = controller.Field.Cells;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var controller = (GuiController)DataContext;
            if (controller.GameStatus == GameStatus.Win || controller.GameStatus == GameStatus.GameOver)
            {
                NewGame();
                return;
            }

            var bindingExpression = ((Button)sender).GetBindingExpression(TagProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            controller.Open(cell);
        }

        private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var controller = (GuiController)DataContext;

            if (controller.GameStatus == GameStatus.Win || controller.GameStatus == GameStatus.GameOver)
            {
                NewGame();
                return;
            }

            var bindingExpression = ((Button)sender).GetBindingExpression(TagProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            controller.Mark(cell);
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Middle)
            {
                return;
            }

            var controller = (GuiController)DataContext;
            if (controller.GameStatus == GameStatus.Win || controller.GameStatus == GameStatus.GameOver)
            {
                NewGame();
                return;
            }

            var bindingExpression = ((Button)sender).GetBindingExpression(TagProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            controller.OpenAroundCells(cell);
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemOptions_OnClick(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow
            {
                DataContext = DataContext
            };
            settingsWindow.ShowDialog();
            NewGame();
        }

        private void MenuItemScores_OnClick(object sender, RoutedEventArgs e)
        {
            var scoresWindow = new HighScoresWindow
            {
                DataContext = DataContext
            };
            scoresWindow.ShowDialog();
            NewGame();
        }

        private void MenuItemNewGame_OnClick(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void MenuItemAbout_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.AboutText);
        }


    }
}
