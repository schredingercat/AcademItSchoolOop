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
            StartNewGame();
        }

        private void StartNewGame()
        {
            var field = new Field(8, 8);
            DataContext = field;
            GameField.ItemsSource = field.Cells;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var field = (Field)DataContext;
            var bindingExpression = ((Button)sender).GetBindingExpression(ContentProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            field.Open(cell);
        }

        private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var field = (Field)DataContext;
            var bindingExpression = ((Button)sender).GetBindingExpression(ContentProperty);
            var cell = (Cell)bindingExpression?.DataItem;
            field.Mark(cell);
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
