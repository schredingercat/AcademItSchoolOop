using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace CsvParse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*" };

            if (openFileDialog.ShowDialog() == true)
            {
                TextBoxFileName.Text = openFileDialog.FileName;
            }
        }

        private void ButtonSaveHtml_OnClick(object sender, RoutedEventArgs e)
        {
            string inputString;

            try
            {
                inputString = File.ReadAllText(TextBoxFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия файла\n{ex.Message}");
                return;
            }

            var outputString = CsvToHtml.ConvertCsvToHtml(inputString);

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "HTML файлы (*.html)|*.html|Все файлы (*.*)|*.*",
                    FileName = "output.html"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, outputString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения файла\n{ex.Message}");
            }
        }

    }
}