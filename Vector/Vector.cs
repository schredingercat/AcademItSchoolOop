using System;
using System.Linq;

namespace Vector
{
    public class Vector
    {
        public double[] Components { get; private set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Размерность вектора должна быть целым положительным числом");
            }
            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            Components = (double[])vector.Components.Clone();
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(components.Length), "Размерность вектора должна быть целым положительным числом");
            }
            Components = (double[])components.Clone();
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0 || components.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(n)}, {nameof(components.Length)}",
                    "Размерность вектора должна быть целым положительным числом");
            }
            Components = new double[n];
            Array.Copy(components, Components, Math.Min(components.Length, Components.Length));
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", Components)}}}";
        }

        public void Add(Vector vector)
        {
            var size = Math.Max(vector.GetSize(), GetSize());

            if (Components.Length < vector.Components.Length)
            {
                var componentsTemp = new double[size];
                Array.Copy(Components, componentsTemp, Components.Length);
                Components = componentsTemp;
            }

            for (int i = 0; i < vector.Components.Length; i++)
            {
                Components[i] += vector.Components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            var size = Math.Max(vector.GetSize(), GetSize());

            if (Components.Length < vector.Components.Length)
            {
                var componentsTemp = new double[size];
                Array.Copy(Components, componentsTemp, Components.Length);
                Components = componentsTemp;
            }

            for (int i = 0; i < vector.Components.Length; i++)
            {
                Components[i] -= vector.Components[i];
            }
        }

        public void Multiply(double factor)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] *= factor;
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
                lengthPow += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(lengthPow);
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= GetLength())
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы размерности вектора");
                }
                return Components[index];
            }
            set
            {
                if (index < 0 || index >= GetLength())
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы размерности вектора");
                }
                Components[index] = value;
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
            return Components.SequenceEqual(vector.Components);
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
            var resultVector = new Vector(vectorA.Components);
            resultVector.Add(vectorB);

            return resultVector;
        }

        public static Vector Subtract(Vector vectorA, Vector vectorB)
        {
            var resultVector = new Vector(vectorA.Components);
            resultVector.Subtract(vectorB);

            return resultVector;
        }

        public static double ScalarProduct(Vector vectorA, Vector vectorB)
        {
            double result = 0;
            double minSize = Math.Min(vectorA.GetSize(), vectorB.GetSize());

            for (int i = 0; i < minSize; i++)
            {
                result += vectorA.Components[i] * vectorB.Components[i];
            }
            return result;
        }
    }
}