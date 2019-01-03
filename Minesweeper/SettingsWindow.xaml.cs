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
                MessageBox.Show(Properties.Resources.WrongWidthInput);
                e.Cancel = true;
                return;

            }
            if (inputWidth < 2 || inputWidth > 30)
            {
                MessageBox.Show(Properties.Resources.WidthOutOfRange);
                e.Cancel = true;
                return;
            }
            
            if (!int.TryParse(TextBoxHeight.Text, out int inputHeight))
            {
                MessageBox.Show(Properties.Resources.WrongHeightInput);
                e.Cancel = true;
                return;
            }
            if (inputHeight < 2 || inputHeight > 16)
            {
                MessageBox.Show(Properties.Resources.HeightOutOfRange);
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(TextBoxMinesCount.Text, out int inputMinesCount))
            {
                MessageBox.Show(Properties.Resources.WrongMinesCountInput);
                e.Cancel = true;
                return;
            }
            if (inputMinesCount < 1 || inputMinesCount > inputHeight * inputHeight - 1)
            {
                MessageBox.Show($"{Properties.Resources.MinesCountOutOfRange} {inputHeight * inputHeight - 1}");
                e.Cancel = true;
                return;
            }

            controller.SaveSettings();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ((GuiController) DataContext)?.SetDifficultLevel(((ToggleButton)sender).Tag.ToString());
        }

        private void SettingsWindow_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var controller = (GuiController)DataContext;

            if (controller.DifficultLevel.Name == Properties.Resources.LevelEasy)
            {
                RadioButtonEasyLevel.IsChecked = true;
            }
            else if (controller.DifficultLevel.Name == Properties.Resources.LevelMedium)
            {
                RadioButtonMediumLevel.IsChecked = true;
            }
            else if (controller.DifficultLevel.Name == Properties.Resources.LevelHard)
            {
                RadioButtonHardLevel.IsChecked = true;
            }
            else if (controller.DifficultLevel.Name == Properties.Resources.LevelCustom)
            {
                RadioButtonCustomLevel.IsChecked = true;
            }
        }
    }
}
