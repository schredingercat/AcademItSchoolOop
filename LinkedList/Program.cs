﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<int>();

            list.Add(3);
            list.Add(14);
            list.Add(15);
            list.Add(92);
            list.Add(6);

            list.AddToTop(17);

            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine($"{i}: {list.GetValueAtIndex(i)}");
            }

            Console.WriteLine();
            list.Invert();

            //Console.WriteLine(list.RemoveByValue(17));
            
            Console.WriteLine($"count: {list.GetCount()}");
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine($"{i}: {list.GetValueAtIndex(i)}");
            }
            Console.WriteLine();

            
            var newList = list.Copy();

            list.SetValueAtIndex(566, 1);
            newList.RemoveFirstItem();

            Console.WriteLine($"list: {list.GetCount()}");
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine($"{i}: {list.GetValueAtIndex(i)}");
            }

            Console.WriteLine();
            Console.WriteLine($"list: {newList.GetCount()}");
            for (int i = 0; i < newList.GetCount(); i++)
            {
                Console.WriteLine($"{i}: {newList.GetValueAtIndex(i)}");
            }



            Console.ReadLine();
        }
    }
}
