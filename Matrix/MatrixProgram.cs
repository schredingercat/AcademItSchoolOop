using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Console.ReadLine();

        }
    }
}
