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

        public Matrix(Matrix matrix)
        {
            var size = matrix._data.Length;
            _data = new RowVector[size];
            for (int i = 0; i < size; i++)
            {
                _data[i] = new RowVector(matrix._data[i]);
            }
        }

        public Matrix(double[,] dataValues)
        {
            _data = new RowVector[dataValues.GetLength(0)];

            for (int i = 0; i < dataValues.GetLength(0); i++)
            {
                _data[i] = new RowVector(dataValues.GetLength(1));
                for (int j = 0; j < dataValues.GetLength(1); j++)
                {
                    _data[i].Components[j] = dataValues[i, j];
                }
            }
        }

        public Matrix(RowVector[] data)
        {
            var size = data.Length;
            _data = new RowVector[size];

            for (int i = 0; i < size; i++)
            {
                _data[i] = new RowVector(data[i]);
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

        public RowVector GetColumn(int index)
        {
            var resultVector = new RowVector(_data.Length);
            for (int i = 0; i < _data.Length; i++)
            {
                resultVector.Components[i] = _data[i].Components[index];
            }

            return resultVector;
        }

        public void SetColumn(RowVector vector, int index)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i].Components[index] = vector.Components[i];
            }
        }

        public void Transpone()
        {
            var resultData = new RowVector[_data[0].GetSize()];
            for (int i = 0; i < resultData.Length; i++)
            {
                resultData[i] = new RowVector(GetColumn(i));
            }

            _data = resultData;
        }

        public void Multiply(double factor)
        {
            foreach (var vector in _data)
            {
                vector.Multiply(factor);
            }
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
