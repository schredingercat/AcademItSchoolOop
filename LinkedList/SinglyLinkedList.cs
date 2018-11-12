using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public void AddToTop(T data)
        {
            var item = new LinkedListItem<T>(data);

            if (count != 0)
            {
                item.Next = head;
            }

            head = item;
            count++;
        }

        public void AddToTop(LinkedListItem<T> item)
        {
            if (count != 0)
            {
                item.Next = head;
            }

            head = item;
            count++;
        }

        public void Insert(T data, int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                AddToTop(data);
                return;
            }

            if (index == count)
            {
                Add(data);
                return;
            }

            var item = head;

            for (int i = 0; i < index - 1; i++)
            {
                item = item.Next;
            }

            var newItem = new LinkedListItem<T>(data)
            {
                Next = item.Next
            };
            item.Next = newItem;
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

        public bool RemoveByValue(T data)
        {
            if (count == 0)
            {
                return false;
            }

            var item = head;

            for (int i = 0; i < count; i++)
            {
                if (item.Data.Equals(data))
                {
                    RemoveAtIndex(i);
                    return true;
                }

                item = item.Next;
            }

            return false;
        }

        public void Invert()
        {
            var item = head;

            while (item.Next != null)
            {
                var temp = item;
                item = item.Next;
                temp.Next = head;
                head = temp;
            }

            item.Next = head;
            head = item;
        }

        public SinglyLinkedList<T> Copy()
        {
            var result = new SinglyLinkedList<T>();

            var item = head;
            var newItem = new LinkedListItem<T>(item.Data);
            result.head = newItem;

            for (int i = 0; i < count; i++)
            {
                newItem.Next = new LinkedListItem<T>(item.Next.Data);
                newItem = newItem.Next;
                item = item.Next;
                result.count++;
            }
            return result;
        }

    }
}
