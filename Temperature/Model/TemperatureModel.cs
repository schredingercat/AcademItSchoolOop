using System;

namespace Temperature.Model
{
    class TemperatureModel
    {
        public Scale InputScale { get; set; }
        public Scale OutputScale { get; set; }
        public double InputTemperature { get; set; }
        public double OutputTemperature { get; private set; }

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
                case Scale.Faringate:
                    if (InputTemperature < absoluteZeroC)
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
                case Scale.Faringate:
                    OutputTemperature = (absoluteTemperature + absoluteZeroC) * 9 / 5 + 32;
                    break;
                case Scale.Kelvin:
                    OutputTemperature = absoluteTemperature;
                    break;
            }
        }
    }
}