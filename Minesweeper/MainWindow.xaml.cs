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
using Minesweeper.Lib;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NewGame(8, 8, 9);
        }

        private void NewGame(int width, int height, int minesCount)
        {
            var controller = new GuiController(width, height, minesCount);
            DataContext = controller;
            GameField.ItemsSource = controller.Field.Cells;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var controller = (GuiController)DataContext;
            if (controller.GameStatus == GameStatus.Win || controller.GameStatus == GameStatus.GameOver)
            {
                NewGame(8, 8, 9);
                return;
            }

            var bindingExpression = ((Button)sender).GetBindingExpression(TagProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            controller.Open(cell);
        }

        private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var controller = (GuiController)DataContext;
            var bindingExpression = ((Button)sender).GetBindingExpression(TagProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            controller.Mark(cell);
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemOptions_OnClick(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
