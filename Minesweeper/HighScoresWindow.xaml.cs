using System.ComponentModel;
using System.Windows;
using Minesweeper.Lib;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for HighScoresWindow.xaml
    /// </summary>
    public partial class HighScoresWindow
    {
        public HighScoresWindow()
        {
            InitializeComponent();
        }

        private void HighScoresWindow_OnClosing(object sender, CancelEventArgs e)
        {
            FileOperations.SaveScores(((GuiController)DataContext).HighScores);
        }

        private void ButtonClearScores_OnClick(object sender, RoutedEventArgs e)
        {
            ((GuiController)DataContext).ClearScores();
            Close();
        }
    }
}
