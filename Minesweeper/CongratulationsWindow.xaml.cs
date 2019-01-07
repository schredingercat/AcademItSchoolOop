using System.Windows;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for CongratulationsWindow.xaml
    /// </summary>
    public partial class CongratulationsWindow
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
