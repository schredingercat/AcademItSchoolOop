using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Temperature.Model;

namespace Temperature.Controller
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
            get => _model.OutputScale;
            set => _model.OutputScale = value;
        }

        public string InputTemperature
        {
            set
            {
                if (!double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double temperature))
                {
                    throw new ArgumentException(@"Введено не числовое значение", nameof(value));
                }
                _model.InputTemperature = temperature;
            }
        }

        public string OutputTemperature
        {
            get
            {
                var units = string.Empty;
                switch (OutputScale)
                {
                    case Scale.Celsius:
                        units = "°C";
                        break;
                    case Scale.Faringate:
                        units = "°F";
                        break;
                    case Scale.Kelvin:
                        units = "K";
                        break;
                }

                return $"{_model.OutputTemperature:F2} {units}";
            }

        }

        public void Convert()
        {
            _model.Convert();
            OnPropertyChanged(nameof(OutputTemperature));
        }

        public void TryConvert(string input)
        {
            try
            {
                InputTemperature = input;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Convert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
