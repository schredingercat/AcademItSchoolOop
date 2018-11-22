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
            var myList = new ArrayList<int>();
            myList.Add(12);
            myList.Add(5);
            myList.Add(19);
            myList.Add(27);
            myList.Add(34);
            myList.Add(8);

            myList.RemoveAt(3);

            Console.WriteLine($"{string.Join(", ", myList)}");

            Console.ReadLine();
        }
    }
}
