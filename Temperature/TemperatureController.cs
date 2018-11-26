using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Temperature
{
    class TemperatureController : INotifyPropertyChanged
    {
        private readonly TemperatureModel _model;

        public TemperatureController()
        {
            _model = new TemperatureModel();
        }

        public Scale InputScale
        {
            set => _model.InputScale = value;
        }

        public Scale OutputScale
        {
            set => _model.OutputScale = value;
        }

        public string InputTemperature
        {
            set
            {
                if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double temperature))
                {
                    throw new ArgumentException(@"Введено не числовое значение", nameof(value));
                }
                _model.InputTemperature = temperature;
            }
        }

        public string OutputTemperature => $"{_model.OutputTemperature:F2}";

        public void Convert()
        {
            _model.Convert();
            OnPropertyChanged(nameof(OutputTemperature));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
