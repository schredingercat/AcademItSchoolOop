using System;
using System.Linq;


namespace Matrix
{
    class Matrix
    {
        private Vector.Vector[] _rows;

        public Matrix(int width, int height)
        {
            _rows = new Vector.Vector[height];

            for (var i = 0; i < height; i++)
            {
                _rows[i] = new Vector.Vector(width);
            }
        }

        public Matrix(Matrix matrix)
        {
            var size = matrix._rows.Length;
            _rows = new Vector.Vector[size];

            for (var i = 0; i < size; i++)
            {
                _rows[i] = new Vector.Vector(matrix._rows[i]);
            }
        }

        public Matrix(double[,] rowValues)
        {
            var wSize = rowValues.GetLength(0);
            var hSize = rowValues.GetLength(1);
            _rows = new Vector.Vector[wSize];

            for (var i = 0; i < wSize; i++)
            {
                _rows[i] = new Vector.Vector(hSize);
                for (var j = 0; j < hSize; j++)
                {
                    _rows[i].Components[j] = rowValues[i, j];
                }
            }
        }

        public Matrix(Vector.Vector[] rows)
        {
            var size = rows.Length;
            _rows = new Vector.Vector[size];

            for (var i = 0; i < size; i++)
            {
                _rows[i] = new Vector.Vector(rows[i]);
            }
        }

        public string GetSize()
        {
            return $"{_rows[0].GetSize()}x{_rows.Length}";
        }

        public Vector.Vector GetRow(int index)
        {
            return _rows[index];
        }

        public void SetRow(Vector.Vector vector, int index)
        {
            var resultVector = new Vector.Vector(_rows[0].GetSize());
            Array.Copy(vector.Components, resultVector.Components, Math.Min(vector.GetSize(), resultVector.GetSize()));
            _rows[index] = resultVector;
        }

        public Vector.Vector GetColumn(int index)
        {
            var resultVector = new Vector.Vector(_rows.Length);
            for (var i = 0; i < _rows.Length; i++)
            {
                resultVector.Components[i] = _rows[i].Components[index];
            }

            return resultVector;
        }

        public void SetColumn(Vector.Vector vector, int index)
        {
            for (var i = 0; i < _rows.Length; i++)
            {
                _rows[i].Components[index] = vector.Components[i];
            }
        }

        public void Transpone()
        {
            var size = _rows[0].GetSize();
            var resultRows = new Vector.Vector[size];
            for (var i = 0; i < size; i++)
            {
                resultRows[i] = new Vector.Vector(GetColumn(i));
            }

            _rows = resultRows;
        }

        public void Multiply(double factor)
        {
            foreach (var vector in _rows)
            {
                vector.Multiply(factor);
            }
        }

        public double GetDeterminant()
        {
            if (_rows.Length != _rows[0].GetSize())
            {
                throw new ArgumentException("Невозможно вычислить определитель не квадратной матрицы");
            }

            var size = _rows.Length;

            if (size == 1)
            {
                return _rows[0].Components[0];
            }

            double determinant = 0;

            for (var i = 0; i < size; i++)
            {
                determinant += Math.Pow(-1, i) * _rows[0].Components[i] * GetMinor(i, 0).GetDeterminant();
            }

            return determinant;
        }

        private Matrix GetMinor(int columnIndex, int rowIndex)
        {
            var size = _rows.Length - 1;
            var resultRows = new Vector.Vector[size];

            for (var i = 0; i < size; i++)
            {
                var vector = new Vector.Vector(size);

                for (var j = 0; j < size; j++)
                {
                    vector.Components[j] = (j < columnIndex) ? _rows[(i < rowIndex) ? i : i + 1].Components[j] : _rows[(i < rowIndex) ? i : i + 1].Components[j + 1];
                }

                resultRows[i] = vector;
            }

            return new Matrix(resultRows);
        }

        public Vector.Vector MultiplyByVector(Vector.Vector vector)
        {
            if (vector.GetSize() != _rows[0].GetSize())
            {
                throw new ArgumentException("Матрица и вектор не согласованы", nameof(vector));
            }

            var wSize = vector.GetSize();
            var hSize = _rows.Length;

            var resultComponents = new double[hSize];
            for (var i = 0; i < hSize; i++)
            {
                for (var j = 0; j < wSize; j++)
                {
                    resultComponents[i] += _rows[i].Components[j] * vector.Components[j];
                }
            }

            return new Vector.Vector(resultComponents);
        }

        public void Add(Matrix matrix)
        {
            if (matrix._rows.Length != _rows.Length || matrix._rows[0].GetSize() != _rows[0].GetSize())
            {
                throw new ArgumentException("Размеры матриц не совпадают", nameof(matrix));
            }

            var size = _rows.Length;
            for (var i = 0; i < size; i++)
            {
                _rows[i].Add(matrix._rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix._rows.Length != _rows.Length || matrix._rows[0].GetSize() != _rows[0].GetSize())
            {
                throw new ArgumentException("Размеры матриц не совпадают", nameof(matrix));
            }

            var size = _rows.Length;
            for (var i = 0; i < size; i++)
            {
                _rows[i].Subtract(matrix._rows[i]);
            }
        }

        public static Matrix Add(Matrix matrixA, Matrix matrixB)
        {
            var resultMatrix = new Matrix(matrixA);
            resultMatrix.Add(matrixB);
            return resultMatrix;
        }

        public static Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            var resultMatrix = new Matrix(matrixA);
            resultMatrix.Subtract(matrixB);
            return resultMatrix;
        }

        public static Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA._rows[0].GetSize() != matrixB._rows.Length)
            {
                throw new ArgumentException("Матрицы не согласованы", $"{nameof(matrixA)}, {nameof(matrixB)}");
            }

            var wSize = matrixB._rows[0].GetSize();
            var hSize = matrixA._rows.Length;

            var resultRows = new double[wSize, hSize];

            for (var i = 0; i < wSize; i++)
            {
                for (var j = 0; j < hSize; j++)
                {
                    resultRows[i, j] = Vector.Vector.ScalarProduct(matrixA.GetRow(i), matrixB.GetColumn(j));
                }
            }

            return new Matrix(resultRows);
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", _rows.ToList())}}}";
        }
    }
}