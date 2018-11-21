using System;
using System.Linq;

namespace Vector
{
    public class Vector
    {
        private double[] _components;

        //public double[] Components
        //{
        //    get => _components;
        //    private set => _components = value;
        //}

        public double[] GetComponents()
        {
            return (double[])_components.Clone();
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Размерность вектора должна быть целым положительным числом");
            }
            _components = new double[n];
        }

        public Vector(Vector vector)
        {
            _components = (double[])vector.GetComponents().Clone();
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(components.Length), "Размерность вектора должна быть целым положительным числом");
            }
            _components = (double[])components.Clone();
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0 || components.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(n)}, {nameof(components.Length)}",
                    "Размерность вектора должна быть целым положительным числом");
            }
            _components = new double[n];
            Array.Copy(components, _components, Math.Min(components.Length, _components.Length));
        }

        public int GetSize()
        {
            return _components.Length;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", _components)}}}";
        }

        public void Add(Vector vector)
        {
            var size = Math.Max(vector.GetSize(), GetSize());

            if (_components.Length < vector._components.Length)
            {
                var componentsTemp = new double[size];
                Array.Copy(_components, componentsTemp, _components.Length);
                _components = componentsTemp;
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] += vector._components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            var size = Math.Max(vector.GetSize(), GetSize());

            if (_components.Length < vector._components.Length)
            {
                var componentsTemp = new double[size];
                Array.Copy(_components, componentsTemp, _components.Length);
                _components = componentsTemp;
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] -= vector._components[i];
            }
        }

        public void Multiply(double factor)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                _components[i] *= factor;
            }
        }

        public void Invert()
        {
            Multiply(-1);
        }

        public double GetLength()
        {
            double lengthPow = 0;

            for (int i = 0; i < GetSize(); i++)
            {
                lengthPow += Math.Pow(_components[i], 2);
            }

            return Math.Sqrt(lengthPow);
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= GetSize())
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы размерности вектора");
                }
                return _components[index];
            }
            set
            {
                if (index < 0 || index >= GetSize())
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы размерности вектора");
                }
                _components[index] = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            var vector = (Vector)obj;
            return _components.SequenceEqual(vector._components);
        }

        public override int GetHashCode()
        {
            var prime = 19;
            var hash = 1;

            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + this[i].GetHashCode();
            }
            return hash;
        }

        public static Vector Add(Vector vectorA, Vector vectorB)
        {
            var resultVector = new Vector(vectorA._components);
            resultVector.Add(vectorB);

            return resultVector;
        }

        public static Vector Subtract(Vector vectorA, Vector vectorB)
        {
            var resultVector = new Vector(vectorA._components);
            resultVector.Subtract(vectorB);

            return resultVector;
        }

        public static double ScalarProduct(Vector vectorA, Vector vectorB)
        {
            double result = 0;
            double minSize = Math.Min(vectorA.GetSize(), vectorB.GetSize());

            for (int i = 0; i < minSize; i++)
            {
                result += vectorA._components[i] * vectorB._components[i];
            }
            return result;
        }
    }
}