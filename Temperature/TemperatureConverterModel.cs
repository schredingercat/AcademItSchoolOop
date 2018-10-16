using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Temperature
{
    public class TemperatureConverterModel :INotifyPropertyChanged
    {
        private const double AbsoluteZero = 273.15;

        private double _temperature;
        private Scale inputScale { get; set; }
        private Scale outputScale { get; set; }

        public Scale InputScale
        {
            get { return inputScale; }
            set
            {
                inputScale = value;
                OnPropertyChanged(nameof(InputScale));
            }
        }

        public Scale OutputScale
        {
            get { return outputScale; }
            set
            {
                outputScale = value;
                OnPropertyChanged(nameof(OutputScale));
            }
        }

        public double InputTemperature
        {
            get
            {
                switch (inputScale)
                {
                    case Scale.Celsius:
                        return _temperature - AbsoluteZero;
                    case Scale.Faringate:
                        return (_temperature - AbsoluteZero) * 9 / 5 + 32;
                    case Scale.Kelvin:
                        return _temperature;
                    default: return _temperature;
                }
            }

            set
            {
                switch (inputScale)
                {
                    case Scale.Celsius:
                        _temperature = value + AbsoluteZero;
                        break;
                    case Scale.Faringate:
                        _temperature = (value - 32) * 5 / 9 + AbsoluteZero;
                        break;
                    case Scale.Kelvin:
                        _temperature = value;
                        break;
                }
                OnPropertyChanged(nameof(InputTemperature));
            }
        }

        public double OutputTemperature
        {
            get
            {
                switch (outputScale)
                {
                    case Scale.Celsius:
                        return _temperature - AbsoluteZero;
                    case Scale.Faringate:
                        return (_temperature - AbsoluteZero) * 9 / 5 + 32;
                    case Scale.Kelvin:
                        return _temperature;
                    default: return _temperature;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public enum Scale
    {
        [Description("°C")]
        Celsius = 1,
        [Description("°F")]
        Faringate,
        [Description("K")]
        Kelvin
    }
}
