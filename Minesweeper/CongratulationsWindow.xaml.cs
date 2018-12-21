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
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for CongratulationsWindow.xaml
    /// </summary>
    public partial class CongratulationsWindow : Window
    {
        public CongratulationsWindow()
        {
            InitializeComponent();
        }

        private void ButtonSaveScores_OnClick(object sender, RoutedEventArgs e)
        {
            ((GuiController)DataContext).AddScores();
            Close();
        }

        private void ButtonDontSave_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
