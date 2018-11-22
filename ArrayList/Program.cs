using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new ArrayList<int>
            {
                12,
                5,
                19,
                27,
                34,
                8
            };

            myList.Remove(27);

            Console.WriteLine($"{string.Join(", ", myList)}");
            Console.WriteLine(myList.Contains(19));
            Console.WriteLine(myList.Contains(95));

            Console.ReadLine();
        }
    }
}
