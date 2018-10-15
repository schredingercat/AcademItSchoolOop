using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RowVector = Vector.Vector;

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

        public double GetDeterminant()
        {
            if (_data.Length != _data[0].GetSize())
            {
                throw new ArgumentException("Невозможно вычислить определитель не квадратной матрицы");
            }

            if (_data.Length == 1)
            {
                return _data[0].Components[0];
            }

            double determinant = 0;

            for (int i = 0; i < _data.Length; i++)
            {
                determinant += Math.Pow(-1, i) * _data[0].Components[i] * GetMinor(i,0).GetDeterminant();
            }

            return determinant;
        }

        private Matrix GetMinor(int columnIndex, int rowIndex)
        {
            var resultData = new RowVector[_data.Length - 1];
            for (int i = 0; i < resultData.Length; i++)
            {
                var vector = new RowVector(resultData.Length);

                for (int j = 0; j < resultData.Length; j++)
                {
                    vector.Components[j] = (j < columnIndex) ? _data[(i < rowIndex) ? i : i + 1].Components[j] : _data[(i < rowIndex) ? i : i + 1].Components[j + 1];
                }

                resultData[i] = vector;
            }
            return new Matrix(resultData);
        }

        public RowVector MultiplyByVector(RowVector vector)
        {
            if (vector.GetSize() != _data[0].GetSize())
            {
                throw new ArgumentException("Матрица и вектор не согласованы");
            }

            var resultComponents = new double[_data.Length];
            for (int i = 0; i < resultComponents.Length; i++)
            {
                for (int j = 0; j < vector.GetSize(); j++)
                {
                    resultComponents[i] += _data[i].Components[j] * vector.Components[j];
                }
            }

            return new RowVector(resultComponents);
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
