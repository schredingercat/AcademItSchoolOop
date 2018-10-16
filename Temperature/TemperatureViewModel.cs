using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Temperature
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        public TemperatureConverterModel TemperatureConverter { get; set; }

        public string InputTemperature
        {
            get { return TemperatureConverter.InputTemperature.ToString(CultureInfo.InvariantCulture); }
            set
            {
                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture,
                    out double result))
                {
                    TemperatureConverter.InputTemperature = result;
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение");
                }

            }
        }

        public Dictionary<Scale, string> DisplayMembers { get; private set; }

        public TemperatureViewModel()
        {
            TemperatureConverter = new TemperatureConverterModel() { InputScale = Scale.Faringate, OutputScale = Scale.Kelvin };
            DisplayMembers = new Dictionary<Scale, string>
            {
                [Scale.Celsius] = "Цельсий",
                [Scale.Faringate] = "Фарингейт",
                [Scale.Kelvin] = "Кельвин"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
