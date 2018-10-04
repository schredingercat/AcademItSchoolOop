using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class VectorProgram
    {
        static void Main()
        {
            Vector vector1 = new Vector(new double[] { 2.3, 4.5, 3 });
            Vector vector2 = new Vector(new double[] { 1, 5, 0, 8 });

            vector1.Subtract(vector2);

            Console.WriteLine(vector1);
            Console.ReadLine();
        }
    }
}
