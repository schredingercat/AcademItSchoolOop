using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class SinglyLinkedList<T>
    {
        private LinkedListItem<T> head;
        private int count;

        public SinglyLinkedList()
        {
            head = new LinkedListItem<T>();
            count = 0;
        }

        public int GetCount()
        {
            return count;
        }

        public T GetHeadValue()
        {
            return head.Data;
        }

        public void Add(T data)
        {
            var item = head;

            for (int i = 0; i < count; i++)
            {
                item = item.Next;
            }

            item.Next = new LinkedListItem<T>(data);
            count++;
        }

        public T GetValueAtIndex(int index)
        {
            if (index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item.Data;
        }

        public void SetValueAtIndex(T data, int index)
        {
            if (index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            item.Data = data;
        }
    }
}
