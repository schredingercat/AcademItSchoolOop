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

        public int GetCount()
        {
            return count;
        }

        public T GetFirstItemValue()
        {
            return head.Data;
        }

        public T RemoveFirstItem()
        {
            var oldData = head.Data;
            head = head.Next;
            count--;
            return oldData;
        }

        public void Add(T data)
        {
            var newItem = new LinkedListItem<T>(data);

            if (head == null)
            {
                head = newItem;
            }
            else
            {
                var item = head;

                while (item.Next != null)
                {
                    item = item.Next;
                }
                item.Next = newItem;
            }
            count++;
        }

        public void AddBeforeFirst(T data)
        {
            var item = new LinkedListItem<T>(data)
            {
                Next = head
            };

            head = item;
            count++;
        }

        public T GetValueAtIndex(int index)
        {
            if (index < 0 || index >= count)
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
            if (index < 0 || index >= count)
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
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                return RemoveFirstItem();
            }

            var item = head;

            for (int i = 0; i < index - 1; i++)
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
