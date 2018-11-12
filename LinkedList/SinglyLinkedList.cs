using System;

namespace LinkedList
{
    class SinglyLinkedList<T>
    {
        private LinkedListItem<T> _head;
        private int _count;

        public int GetCount()
        {
            return _count;
        }

        public T GetFirstItemValue()
        {
            return _head.Data;
        }

        public T RemoveFirstItem()
        {
            var oldData = _head.Data;
            _head = _head.Next;
            _count--;
            return oldData;
        }

        public void Add(T data)
        {
            var newItem = new LinkedListItem<T>(data);

            if (_head == null)
            {
                _head = newItem;
            }
            else
            {
                var item = _head;

                while (item.Next != null)
                {
                    item = item.Next;
                }
                item.Next = newItem;
            }
            _count++;
        }

        public void AddToTop(T data)
        {
            var item = new LinkedListItem<T>(data);

            if (_count != 0)
            {
                item.Next = _head;
            }

            _head = item;
            _count++;
        }

        public void AddToTop(LinkedListItem<T> item)
        {
            if (_count != 0)
            {
                item.Next = _head;
            }

            _head = item;
            _count++;
        }

        public void Insert(T data, int index)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                AddToTop(data);
                return;
            }

            if (index == _count)
            {
                Add(data);
                return;
            }

            var item = _head;

            for (int i = 0; i < index - 1; i++)
            {
                item = item.Next;
            }

            var newItem = new LinkedListItem<T>(data)
            {
                Next = item.Next
            };
            item.Next = newItem;
            _count++;
        }

        public T GetValueAtIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = _head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item.Data;
        }

        public T SetValueAtIndex(T data, int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = _head;

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
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                return RemoveFirstItem();
            }

            var item = _head;

            for (int i = 0; i < index - 1; i++)
            {
                item = item.Next;
            }

            var oldData = item.Next.Data;
            item.Next = item.Next.Next;

            _count--;
            return oldData;
        }

        public bool RemoveByValue(T data)
        {
            if (_count == 0)
            {
                return false;
            }

            var item = _head;

            for (int i = 0; i < _count; i++)
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
            var item = _head;

            while (item.Next != null)
            {
                var temp = item;
                item = item.Next;
                temp.Next = _head;
                _head = temp;
            }

            item.Next = _head;
            _head = item;
        }

        public SinglyLinkedList<T> Copy()
        {
            var result = new SinglyLinkedList<T>();

            var item = _head;
            var newItem = new LinkedListItem<T>(item.Data);
            result._head = newItem;

            for (int i = 0; i < _count; i++)
            {
                newItem.Next = new LinkedListItem<T>(item.Next.Data);
                newItem = newItem.Next;
                item = item.Next;
                result._count++;
            }
            return result;
        }

        public override string ToString()
        {
            var item = _head;
            var result = item.Data.ToString();

            for (int i = 0; i < _count - 1; i++)
            {
                item = item.Next;
                result += $", {item.Data}";
            }

            return result;
        }

    }
}