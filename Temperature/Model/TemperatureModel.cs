using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Temperature.Model
{
    class TemperatureModel
    {
        public Scale InputScale { get; set; }
        public Scale OutputScale { get; set; }
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

        public void AddScale(string name, double factor, double offset)
        {
            InputScales.Add(new TemperatureScale(){Name = name, Factor = factor, Offset = offset});
            OutputScales.Add(new TemperatureScale() { Name = name, Factor = factor, Offset = offset });
        }

        public void ConvertToK()
        {
            
            var absoluteTemperature = ((SelectedInputScale.Factor) * (InputTemperature - SelectedInputScale.Offset) + 273.15);

            if (absoluteTemperature < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(InputTemperature), $@"Температура не может быть ниже абсолютного нуля");
            }

            OutputTemperature = ((absoluteTemperature - 273.15)/ (SelectedOutputScale.Factor) +
                                 SelectedOutputScale.Offset);
            
        }

        public void Convert()
        {
            const double absoluteZeroC = -273.15;
            const double absoluteZeroF = -459.67;
            const double absoluteZeroK = 0;

            var absoluteTemperature = 0.0;

            switch (InputScale)
            {
                case Scale.Celsius:
                    if (InputTemperature < absoluteZeroC)
                    {
                        throw new ArgumentOutOfRangeException(nameof(InputTemperature), $@"Температура не может быть ниже {absoluteZeroC} °C");
                    }
                    absoluteTemperature = InputTemperature - absoluteZeroC;
                    break;
                case Scale.Fahrenheit:
                    if (InputTemperature < absoluteZeroF)
                    {
                        throw new ArgumentOutOfRangeException(nameof(InputTemperature), $@"Температура не может быть ниже {absoluteZeroF} °F");
                    }
                    absoluteTemperature = (InputTemperature - 32) * 5 / 9 - absoluteZeroC;
                    break;
                case Scale.Kelvin:
                    if (InputTemperature < absoluteZeroK)
                    {
                        throw new ArgumentOutOfRangeException(nameof(InputTemperature), $@"Температура не может быть ниже {absoluteZeroK} K");
                    }
                    absoluteTemperature = InputTemperature;
                    break;
            }

            switch (OutputScale)
            {
                case Scale.Celsius:
                    OutputTemperature = absoluteTemperature + absoluteZeroC;
                    break;
                case Scale.Fahrenheit:
                    OutputTemperature = (absoluteTemperature + absoluteZeroC) * 9 / 5 + 32;
                    break;
                case Scale.Kelvin:
                    OutputTemperature = absoluteTemperature;
                    break;
            }
        }
    }
}