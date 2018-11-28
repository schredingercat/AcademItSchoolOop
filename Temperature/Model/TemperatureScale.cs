using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Model
{
    public class TemperatureScale
    {
        private const double AbsoluteZero = -273.15;

        public string Name { get; set; }
        public double Factor { get; set; }
        public double Offset { get; set; }
        public string Symbol { get; set; }
    }
}
