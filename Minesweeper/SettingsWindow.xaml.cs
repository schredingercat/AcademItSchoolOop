using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var controller = (GuiController) DataContext;
            
            if (!int.TryParse(TextBoxWidth.Text, out int inputWidth))
            {
                MessageBox.Show("Неверный ввод ширины");
                e.Cancel = true;
                return;
            }
            if (inputWidth < 2 || inputWidth > 30)
            {
                MessageBox.Show("Ширина игрового поля должна быть от 2 до 30");
                e.Cancel = true;
                return;
            }
            
            if (!int.TryParse(TextBoxHeight.Text, out int inputHeight))
            {
                MessageBox.Show("Неверный ввод!");
                e.Cancel = true;
                return;
            }
            if (inputHeight < 2 || inputHeight > 16)
            {
                MessageBox.Show("Высота игрового поля должна быть от 2 до 16");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(TextBoxMinesCount.Text, out int inputMinesCount))
            {
                MessageBox.Show("Неверный ввод!");
                e.Cancel = true;
                return;
            }
            if (inputMinesCount < 1 || inputMinesCount > inputHeight * inputHeight - 1)
            {
                MessageBox.Show($"Количество мин должно быть от 1 до {inputHeight * inputHeight - 1}");
                e.Cancel = true;
                return;
            }

            controller.SaveSettings();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ((GuiController) DataContext)?.SetDifficultLevel(((ToggleButton)sender).Tag.ToString());
        }
    }
}
