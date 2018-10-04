using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        public double[] Components { get; private set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            Components = (double[])vector.Components.Clone();
        }

        public Vector(double[] components)
        {
            Components = (double[])components.Clone();
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
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

        public void Merge(Vector vector)
        {
            var vectorA = new double[Math.Max(vector.Components.Length, Components.Length)];
            Array.Copy(Components, vectorA, Components.Length);
            var vectorB = new double[vectorA.Length];
            Array.Copy(vector.Components, vectorB, vector.Components.Length);
            Components = new double[vectorA.Length];

            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] = vectorA[i] + vectorB[i];
            }
        }

        public void Subtract(Vector vector)
        {
            var vectorA = new double[Math.Max(vector.GetSize(), GetSize())];
            Array.Copy(Components, vectorA, GetSize());

            var vectorB = new double[vectorA.Length];
            Array.Copy(vector.Components, vectorB, vector.GetSize());

            Components = new double[vectorA.Length];

            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] = vectorA[i] - vectorB[i];
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



    }
}
