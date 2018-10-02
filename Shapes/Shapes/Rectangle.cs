using System;

namespace Shapes.Shapes
{
    class Rectangle : IShape
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double GetArea()
        {
            return _width * _height;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetPerimeter()
        {
            return (_width + _height) * 2;
        }

        public double GetWidth()
        {
            return _width;
        }

        public override string ToString()
        {
            return $"Прямоугольник, площадь: {GetArea():0.####}, периметр: {GetPerimeter():0.####}, ширина: {_width:0.####}, высота {_height:0.####}";
        }

        public override int GetHashCode()
        {
            return (_width + _height).GetHashCode();
        }

        public override bool Equals(object objectToCompare)
        {
            if (!(objectToCompare is Rectangle rectangle))
            {
                return false;
            }

            if ((Math.Abs(rectangle._width - _width) < 1E-10) && (Math.Abs(rectangle._height - _height) < 1E-10))
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