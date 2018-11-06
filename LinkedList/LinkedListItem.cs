using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedListItem<T>
    {
        public T Data { get; set; }
        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem(T data)
        {
            Data = data;
        }

        public LinkedListItem(T data, LinkedListItem<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}
