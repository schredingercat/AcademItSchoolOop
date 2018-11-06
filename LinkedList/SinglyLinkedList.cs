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

        public T RemoveFirstItem()
        {
            var oldData = head.Data;
            head = head.Next;
            return oldData;
        }

        public void Add(T data)
        {
            if (count == 0)
            {
                head = new LinkedListItem<T>(data);
                count++;
                return;
            }

            var item = head;
            for (int i = 0; i < count-1; i++)
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

        public T SetValueAtIndex(T data, int index)
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

            var oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        public T RemoveAtIndex(int index)
        {
            if (index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = head;

            for (int i = 0; i < index-1; i++)
            {
                item = item.Next;
            }

            var oldData = item.Next.Data;
            item.Next = item.Next.Next;
            count--;
            return oldData;
        }
    }
}
