using System;
using System.Globalization;
using System.Windows.Data;
using Minesweeper.Lib;

namespace Minesweeper
{
    class GameStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = "../images/face_wait.png";
            if (value != null)
                switch ((GameStatus)value)
                {
                    case GameStatus.Playing:
                        source = "../images/face_playing.png";
                        break;
                    case GameStatus.GameOver:
                        source = "../images/face_gameover.png";
                        break;
                    case GameStatus.Win:
                        source = "../images/face_win.png";
                        break;
                }

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}