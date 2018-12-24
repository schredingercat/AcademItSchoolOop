using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for HighScoresWindow.xaml
    /// </summary>
    public partial class HighScoresWindow : Window
    {
        public HighScoresWindow()
        {
            InitializeComponent();
        }

        private void HighScoresWindow_OnClosing(object sender, CancelEventArgs e)
        {
            ((GuiController)DataContext).SaveScores();
        }

        private void ButtonClearScores_OnClick(object sender, RoutedEventArgs e)
        {
            ((GuiController)DataContext).ClearScores();
        }
    }
}
