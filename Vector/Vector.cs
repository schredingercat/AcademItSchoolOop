using System;
using System.Linq;

namespace Vector
{
    class Vector
    {
        public double[] Components { get; private set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
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
                throw new ArgumentOutOfRangeException();
            }
            Components = (double[])components.Clone();
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0 || components.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
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

            var componentsA = new double[size];
            Array.Copy(Components, componentsA, Components.Length);
            var componentsB = new double[size];
            Array.Copy(vector.Components, componentsB, vector.Components.Length);
            Components = new double[size];

            for (int i = 0; i < size; i++)
            {
                Components[i] = componentsA[i] + componentsB[i];
            }
        }

        public void Subtract(Vector vector)
        {
            var size = Math.Max(vector.GetSize(), GetSize());

            var componentsA = new double[size];
            Array.Copy(Components, componentsA, Components.Length);
            var componentsB = new double[size];
            Array.Copy(vector.Components, componentsB, vector.Components.Length);
            Components = new double[size];

            for (int i = 0; i < size; i++)
            {
                Components[i] = componentsA[i] - componentsB[i];
            }
        }

        public void Multiply(double factor)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] = Components[i] * factor;
            }
        }

        public void Invert()
        {
            Multiply(-1);
        }

        public double GetLength()
        {
            double length = 0;

            for (int i = 0; i < GetSize(); i++)
            {
                length += Math.Pow(Components[i], 2);
            }
            length = Math.Sqrt(length);

            return length;
        }

        public double GetComponent(int index)
        {
            if (index < GetLength())
            {
                return Components[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetComponent(int index, double value)
        {
            if (index < GetLength())
            {
                Components[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
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
                hash = prime * hash + GetComponent(i).GetHashCode();
            }
            return hash;
        }

        public static Vector Add(Vector vectorA, Vector vectorB)
        {
            var size = Math.Max(vectorA.GetSize(), vectorB.GetSize());
            var componentsA = new double[size];
            Array.Copy(vectorA.Components, componentsA, vectorA.Components.Length);
            var componentsB = new double[size];
            Array.Copy(vectorB.Components, componentsB, vectorB.Components.Length);

            var resultVector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                resultVector.Components[i] = componentsA[i] + componentsB[i];
            }
            return resultVector;
        }

        public static Vector Subtract(Vector vectorA, Vector vectorB)
        {
            var size = Math.Max(vectorA.GetSize(), vectorB.GetSize());
            var componentsA = new double[size];
            Array.Copy(vectorA.Components, componentsA, vectorA.Components.Length);
            var componentsB = new double[size];
            Array.Copy(vectorB.Components, componentsB, vectorB.Components.Length);

            var resultVector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                resultVector.Components[i] = componentsA[i] - componentsB[i];
            }
            return resultVector;
        }

        public static double ScalarProduct(Vector vectorA, Vector vectorB)
        {
            var size = Math.Max(vectorA.GetSize(), vectorB.GetSize());
            var componentsA = new double[size];
            Array.Copy(vectorA.Components, componentsA, vectorA.Components.Length);
            var componentsB = new double[size];
            Array.Copy(vectorB.Components, componentsB, vectorB.Components.Length);

            double result = 0;

            for (int i = 0; i < size; i++)
            {
                result += componentsA[i] * componentsB[i];
            }
            return result;
        }
    }
}