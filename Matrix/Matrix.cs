using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        private Vector.Vector[] _data;

        public Matrix(int n, int m)
        {
            _data = new Vector.Vector[m];
            for (int i = 0; i < m; i++)
            {
                _data[i] = new Vector.Vector(n);
            }
        }

        public override string ToString()
        {

            return " ";
        }
    }
}
