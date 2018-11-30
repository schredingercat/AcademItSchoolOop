using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Temperature.Model;

namespace Temperature.Controller
{
    class TemperatureController : INotifyPropertyChanged
    {
        private readonly TemperatureModel _model;

        public BindingList<TemperatureScale> InputScales => _model.InputScales;
        public BindingList<TemperatureScale> OutputScales => _model.OutputScales;

        public TemperatureScale SelectedInputScale
        {
            get => _model.SelectedInputScale;
            set => _model.SelectedInputScale = value;
        }

        public TemperatureScale SelectedOutputScale
        {
            get => _model.SelectedOutputScale;
            set => _model.SelectedOutputScale = value;
        }

        public TemperatureController()
        {
            _model = new TemperatureModel();
            _model.AddScale("Цельсия", 0, 100);
            _model.AddScale("Фаренгейта", 32, 212);
            _model.AddScale("Кельвина", 273.15, 373.15);
            _model.SelectedInputScale = _model.InputScales[0];
            _model.SelectedOutputScale = _model.OutputScales[1];
        }

        public void AddScale(string name, string inputZeroC, string inputHundredC)
        {
            const double absoluteZero = -273.15;
            if (name.Length <= 0 || !double.TryParse(inputZeroC.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out var zeroC)
                                 || !double.TryParse(inputHundredC.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out var hundredC))
            {
                throw new ArgumentException(@"Введены некорректные значения", $"{nameof(name)}, {nameof(inputZeroC)}, {nameof(inputHundredC)}");
            }

            if (InputScales.Any(n => n.Name == name))
            {
                throw new ArgumentException($@"Шкала {name} уже есть в списке", nameof(name));
            }

            if (zeroC >= hundredC || zeroC < absoluteZero || hundredC < absoluteZero)
            {
                throw new ArgumentOutOfRangeException($"{nameof(zeroC)}, {nameof(hundredC)}", @"Введены некорректные значения для 0 и 100 градусов");
            }

            _model.AddScale(name, zeroC, hundredC);
        }

        public string InputTemperature
        {
            set
            {
                if (!double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var temperature))
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