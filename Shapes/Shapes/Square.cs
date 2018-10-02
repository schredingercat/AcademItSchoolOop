using System;

namespace Shapes
{
    class Square : IShape
    {
        private readonly double _sideLength;

        public Square(double sideLength)
        {
            _sideLength = sideLength;
        }

        public double GetArea()
        {
            return Math.Pow(_sideLength, 2);
        }

        public double GetHeight()
        {
            return _sideLength;
        }

        public double GetPerimeter()
        {
            return _sideLength * 4;
        }

        public double GetWidth()
        {
            return _sideLength;
        }

        public override string ToString()
        {
            return $"Квадрат, площадь: {GetArea():0.####}, периметр: {GetPerimeter():0.####}, сторона: {_sideLength:0.####}";
        }

        public override int GetHashCode()
        {
            return _sideLength.GetHashCode();
        }

        public override bool Equals(object objectToCompare)
        {
            if (!(objectToCompare is Square square))
            {
                return false;
            }

            if (Math.Abs(square._sideLength - _sideLength) < 1E-10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}