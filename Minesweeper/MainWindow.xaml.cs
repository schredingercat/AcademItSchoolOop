﻿using System;
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

            var field = new Field(8, 8);
            GameField.ItemsSource = field.Cells;


        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var bindingExpression = ((Button) sender).GetBindingExpression(Button.ContentProperty);

            var item = (Cell)bindingExpression?.DataItem;
            
            MessageBox.Show($"{item?.Text}");
        }
    }
}
