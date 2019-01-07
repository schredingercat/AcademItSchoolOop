using System;
using System.Globalization;
using System.Windows.Data;
using Minesweeper.Lib;

namespace Minesweeper
{
    class CellStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = "../images/hidden.png";
            if (value == null)
            {
                return source;
            }

            switch ((CellStatus)value)
            {
                case CellStatus.Hidden:
                    source = "../images/hidden.png";
                    break;
                case CellStatus.Mine:
                    source = "../images/mine.png";
                    break;
                case CellStatus.Marked:
                    source = "../images/flag.png";
                    break;
                case CellStatus.Number0:
                    source = "../images/0.png";
                    break;
                case CellStatus.Number1:
                    source = "../images/1.png";
                    break;
                case CellStatus.Number2:
                    source = "../images/2.png";
                    break;
                case CellStatus.Number3:
                    source = "../images/3.png";
                    break;
                case CellStatus.Number4:
                    source = "../images/4.png";
                    break;
                case CellStatus.Number5:
                    source = "../images/5.png";
                    break;
                case CellStatus.Number6:
                    source = "../images/6.png";
                    break;
                case CellStatus.Number7:
                    source = "../images/7.png";
                    break;
                case CellStatus.Number8:
                    source = "../images/8.png";
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