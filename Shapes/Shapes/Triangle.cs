using System;

namespace Shapes.Shapes
{
    class Triangle : IShape
    {
        private readonly double _x1;
        private readonly double _y1;
        private readonly double _x2;
        private readonly double _y2;
        private readonly double _x3;
        private readonly double _y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            _x3 = x3;
            _y3 = y3;
        }

        public double GetArea()
        {
            var lengthA = GetSideLength(_x1, _y1, _x2, _y2);
            var lengthB = GetSideLength(_x2, _y2, _x3, _y3);
            var lengthC = GetSideLength(_x3, _y3, _x1, _y1);
            var halfPerimeter = (lengthA + lengthB + lengthC) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - lengthA)
                                           * (halfPerimeter - lengthB)
                                           * (halfPerimeter - lengthC));
        }

        public double GetHeight()
        {
            return Math.Max(_y1, Math.Max(_y2, _y3)) - Math.Min(_y1, Math.Min(_y2, _y3));
        }

        public double GetPerimeter()
        {
            var lengthA = GetSideLength(_x1, _y1, _x2, _y2);
            var lengthB = GetSideLength(_x2, _y2, _x3, _y3);
            var lengthC = GetSideLength(_x3, _y3, _x1, _y1);

            return lengthA + lengthB + lengthC;
        }

        public double GetWidth()
        {
            return Math.Max(_x1, Math.Max(_x2, _x3)) - Math.Min(_x1, Math.Min(_x2, _x3));
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public override string ToString()
        {
            var lengthA = GetSideLength(_x1, _y1, _x2, _y2);
            var lengthB = GetSideLength(_x2, _y2, _x3, _y3);
            var lengthC = GetSideLength(_x3, _y3, _x1, _y1);
            return
                $"Треугольник, площадь: {GetArea():0.####}, периметр: {GetPerimeter():0.####}, стороны: {lengthA:0.####}, {lengthB:0.####}, {lengthC:0.####}";
        }

        public override int GetHashCode()
        {
            var prime = 19;
            var hash = 1;

            hash = prime * hash + _x1.GetHashCode();
            hash = prime * hash + _x2.GetHashCode();
            hash = prime * hash + _x3.GetHashCode();
            hash = prime * hash + _y1.GetHashCode();
            hash = prime * hash + _y2.GetHashCode();
            hash = prime * hash + _y3.GetHashCode();

            return hash;
        }

        public override bool Equals(object objectToCompare)
        {
            if (ReferenceEquals(objectToCompare, this))
            {
                return true;
            }

            if (ReferenceEquals(objectToCompare, null) || objectToCompare.GetType() != GetType())
            {
                return false;
            }

            var triangle = (Triangle)objectToCompare;

            return triangle._x1 == _x1 && triangle._y1 == _y1
                                       && triangle._x2 == _x2 && triangle._y2 == _y2
                                       && triangle._x3 == _x3 && triangle._y3 == _y3;
        }
    }
}