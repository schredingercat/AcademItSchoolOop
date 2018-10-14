using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RowVector= Vector.Vector;

namespace Matrix
{
    class Matrix
    {
        private RowVector[] _data;

        public Matrix(int n, int m)
        {
            _data = new RowVector[m];
            for (int i = 0; i < m; i++)
            {
                _data[i] = new RowVector(n);
            }
        }

        public string GetSize()
        {
            return $"{_data[0].GetSize()}x{_data.Length}";
        }

        public RowVector GetRow(int index)
        {
            return _data[index];
        }

        public void SetRow(RowVector vector, int index)
        {
            var resultVector = new RowVector(_data[0].GetSize());
            Array.Copy(vector.Components, resultVector.Components, Math.Min(vector.GetSize(), resultVector.GetSize()));
            _data[index] = resultVector;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var vector in _data)
            {
                result += vector;
            }
            return $"{{{result}}}";
        }
    }
}
