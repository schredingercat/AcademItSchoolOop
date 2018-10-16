using System;
using RowVector = Vector.Vector;

namespace Matrix
{
    class MatrixProgram
    {
        static void Main()
        {
            var matrix1 = new Matrix(3,4);
            Console.WriteLine(matrix1);
            Console.WriteLine(matrix1.GetSize());
            
            var matrix2 = new Matrix(matrix1);
            Console.WriteLine(matrix2);
            Console.WriteLine(matrix2.GetSize());

            var matrix3 = new Matrix(new double[,]{{1,2,3},{4,5,6}, { 7, 8, 9 } });
            Console.WriteLine(matrix3);
            Console.WriteLine(matrix3.GetSize());

            var matrix4 = new Matrix(new RowVector[]{new RowVector(new double[]{12,23,34,56}), new RowVector(new double[] { 65, 83, 45, 44 }), new RowVector(new double[] { 3, 5, 8, 9 }) });
            Console.WriteLine(matrix4);
            Console.WriteLine(matrix4.GetSize());


            Console.WriteLine($"Строка {matrix4.GetRow(1)}");
            matrix4.SetRow(new RowVector(new double[] { 18, 19, 20, 21 }), 0);
            Console.WriteLine(matrix4);

            Console.WriteLine($"Столбец {matrix4.GetColumn(1)}");
            matrix4.SetColumn(new RowVector(new double[] { 16, 17, 25 }), 2);
            Console.WriteLine(matrix4);

            Console.WriteLine();
            matrix4.Transpone();
            Console.WriteLine(matrix4);
            Console.WriteLine(matrix4.GetSize());

            matrix4.Multiply(10);
            Console.WriteLine(matrix4);

            Console.WriteLine();
            var matrix0 = new Matrix(new double[,] { { 3, 14, 15 }, { 92, 6, 5 }, {4, 32, 17} });
            Console.WriteLine(matrix0);
            Console.WriteLine(matrix0.GetDeterminant());


            Console.WriteLine();
            Console.WriteLine(matrix3);
            Console.WriteLine(matrix3.GetDeterminant());

            Console.WriteLine();
            Console.WriteLine(matrix4);
            Console.WriteLine(matrix4.GetSize());
            var vector = new RowVector(new RowVector(new double[] { 1, 2, 4 }));
            Console.WriteLine($"{matrix4} x {vector} = {matrix4.MultiplyByVector(vector)}");

            Console.WriteLine();
            var matrix15 = new Matrix(new double[,] { { 3, 14, 15 }, { 92, 6, 5 }, { 4, 32, 17 } });
            var matrix16 = new Matrix(new double[,] { { 13, 24, 45 }, { 2, 86, 15 }, { 24, 2, 7 } });
            Console.Write($"{matrix15} + {matrix16} = ");
            matrix15.Add(matrix16);
            Console.WriteLine($"{matrix15}");
            Console.Write($"{matrix15} - {matrix16} = ");
            matrix15.Subtract(matrix16);
            Console.WriteLine($"{matrix15}");

            Console.WriteLine();
            Console.WriteLine("Произведение матриц");

            var matrix25 = new Matrix(new double[,] { { 1, 2, 3 ,4}, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            var matrix26 = new Matrix(new double[,] { { 10, 12, 34 }, { 15, 8, 47 }, { 25, 19, 4 }, { 55, 2, 94 } });

            Console.WriteLine(matrix25);
            Console.WriteLine(matrix26);
            Console.WriteLine(Matrix.Multiply(matrix25, matrix26));



            Console.ReadLine();

        }
    }
}
