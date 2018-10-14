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
            var matrix = new Matrix(3,4);

            Console.WriteLine(matrix);
            Console.WriteLine(matrix.GetSize());

            var vector = new RowVector(new double[] {1, 2});

            matrix.SetRow(vector,1);
            Console.WriteLine(matrix);

            Console.ReadLine();

        }
    }
}
