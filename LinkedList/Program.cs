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
            list.Insert(256, 5);
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine($"{i}: {list.GetValueAtIndex(i)}");
            }


            Console.ReadLine();
        }
    }
}
