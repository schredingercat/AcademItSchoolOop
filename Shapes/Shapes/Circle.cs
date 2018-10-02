using System;

namespace Shapes.Shapes
{
    class Circle : IShape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public double GetHeight()
        {
            return _radius * 2;
        }

        public double GetPerimeter()
        {
            return Math.PI * 2 * _radius;
        }

        public double GetWidth()
        {
            return _radius * 2;
        }

        public override string ToString()
        {
            return $"Круг, площадь: {GetArea():0.####}, периметр: {GetPerimeter():0.####}, радиус: {_radius:0.####}";
        }

        public override int GetHashCode()
        {
            return _radius.GetHashCode();
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

            var circle = (Circle)objectToCompare;

            return circle._radius.Equals(_radius);
        }
    }
}