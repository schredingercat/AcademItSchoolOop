using System;
using System.ComponentModel;

namespace Temperature.Model
{
    class TemperatureModel
    {
        public double InputTemperature { get; set; }
        public double OutputTemperature { get; private set; }

        public BindingList<TemperatureScale> InputScales { get; set; }
        public BindingList<TemperatureScale> OutputScales { get; set; }
        public TemperatureScale SelectedInputScale { get; set; }
        public TemperatureScale SelectedOutputScale { get; set; }

        public TemperatureModel()
        {
            InputScales = new BindingList<TemperatureScale>();
            OutputScales = new BindingList<TemperatureScale>();
        }

        public void AddScale(string name, double zeroC, double hundredC)
        {
            const double hundred = 100;
            var factor = hundred / (hundredC - zeroC);

            InputScales.Add(new TemperatureScale { Name = name, Factor = factor, Offset = zeroC });
            OutputScales.Add(new TemperatureScale { Name = name, Factor = factor, Offset = zeroC });
        }

        public void Convert()
        {

            var absoluteTemperature = SelectedInputScale.Factor * (InputTemperature - SelectedInputScale.Offset) + 273.15;

            if (absoluteTemperature < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(InputTemperature), @"Температура не может быть ниже абсолютного нуля");
            }

            OutputTemperature = (absoluteTemperature - 273.15) / SelectedOutputScale.Factor + SelectedOutputScale.Offset;
        }
    }
}