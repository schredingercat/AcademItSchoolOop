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
            var prime = 19;
            var hash = 1;

            hash = prime * hash + _width.GetHashCode();
            hash = prime * hash + _height.GetHashCode();

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

            var rectangle = (Rectangle)objectToCompare;

            return rectangle._width == _width && rectangle._height == _height;
        }
    }
}