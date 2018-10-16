using System;
using RowVector = Vector.Vector;

namespace Matrix
{
    class MatrixProgram
    {
        static void Main()
        {
            var matrix1 = new Matrix(3, 4);
            Console.WriteLine($"{nameof(matrix1)}: {matrix1}");

            var matrix2 = new Matrix(matrix1);
            Console.WriteLine($"{nameof(matrix2)}: {matrix2}");

            var matrix3 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Console.WriteLine($"{nameof(matrix3)}: {matrix3}");

            var matrix4 = new Matrix(new[] { new RowVector(new double[] { 12, 23, 34, 56 }), new RowVector(new double[] { 65, 83, 45, 44 }), new RowVector(new double[] { 3, 5, 8, 9 }) });
            Console.WriteLine($"{nameof(matrix4)}: {matrix4}");

            Console.WriteLine();
            Console.WriteLine($"Размеры {nameof(matrix4)}: {matrix4.GetSize()}");

            Console.WriteLine();
            Console.WriteLine($"Получение строки: {matrix4.GetRow(1)}");
            Console.Write($"Установка строки: ");
            matrix4.SetRow(new RowVector(new double[] { 18, 19, 20, 21 }), 0);
            Console.WriteLine(matrix4);

            Console.WriteLine();
            Console.WriteLine($"Получение столбца {matrix4.GetColumn(1)}");
            Console.Write($"Установка столбца: ");
            matrix4.SetColumn(new RowVector(new double[] { 16, 17, 25 }), 2);
            Console.WriteLine(matrix4);

            Console.WriteLine();
            Console.WriteLine($"Транспонирование матрицы");
            Console.WriteLine($"{matrix4} - {matrix4.GetSize()}");
            matrix4.Transpone();
            Console.WriteLine($"{matrix4} - {matrix4.GetSize()}");

            Console.WriteLine();
            matrix4.Multiply(10);
            Console.WriteLine($"Умножение на 10: {matrix4}");

            Console.WriteLine();
            var matrix = new Matrix(new double[,] { { 3, 14, 15 }, { 92, 6, 5 }, { 4, 32, 17 } });
            Console.WriteLine($"Определитель матрицы {matrix} равен {matrix.GetDeterminant()}");
            Console.WriteLine($"Определитель матрицы {matrix3} равен {matrix3.GetDeterminant()}");

            Console.WriteLine();
            Console.WriteLine("Умножение матрицы на вектор");
            var vector = new RowVector(new RowVector(new double[] { 1, 2, 4 }));
            Console.WriteLine($"{matrix4} x {vector} = {matrix4.MultiplyByVector(vector)}");

            Console.WriteLine();
            Console.WriteLine("Сложение и вычитание матриц");
            var matrix5 = new Matrix(new double[,] { { 3, 1, 5 }, { 9, 6, 5 }, { 4, 3, 7 } });
            var matrix6 = new Matrix(new double[,] { { 1, 4, 4 }, { 2, 8, 1 }, { 2, 2, 7 } });
            Console.Write($"{matrix5} + {matrix6} = ");
            matrix5.Add(matrix6);
            Console.WriteLine($"{matrix5}");
            Console.Write($"{matrix5} - {matrix6} = ");
            matrix5.Subtract(matrix6);
            Console.WriteLine($"{matrix5}");

            Console.WriteLine();
            Console.WriteLine($"{matrix} + {matrix3} = {Matrix.Add(matrix, matrix3)}");
            Console.WriteLine($"{matrix} - {matrix3} = {Matrix.Subtract(matrix, matrix3)}");
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Произведение матриц");

            var matrix7 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            var matrix8 = new Matrix(new double[,] { { 10, 12, 34 }, { 15, 8, 47 }, { 25, 19, 4 }, { 55, 2, 94 } });

            Console.WriteLine($"{matrix7} x {matrix8} = ");
            Console.WriteLine(Matrix.Multiply(matrix7, matrix8));

            Console.ReadLine();
        }
    }
}