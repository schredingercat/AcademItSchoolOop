using System;
using System.Text;

namespace LinkedList
{
    class SinglyLinkedList<T>
    {
        private LinkedListItem<T> _head;
        public int Count { get; private set; }

        public T GetFirstItemValue()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            return _head.Data;
        }

        public T RemoveFirstItem()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            var oldData = _head.Data;
            _head = _head.Next;
            Count--;
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
                GetItem(Count - 1).Next = newItem;
            }
            Count++;
        }

        public void AddToTop(T data)
        {
            var item = new LinkedListItem<T>(data);

            if (Count != 0)
            {
                item.Next = _head;
            }

            _head = item;
            Count++;
        }

        public void Insert(T data, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                AddToTop(data);
                return;
            }

            if (index == Count)
            {
                Add(data);
                return;
            }

            var item = GetItem(index - 1);

            var newItem = new LinkedListItem<T>(data)
            {
                Next = item.Next
            };
            item.Next = newItem;
            Count++;
        }

        public T GetValueAtIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = GetItem(index);

            return item.Data;
        }

        public T SetValueAtIndex(T data, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            var item = GetItem(index);

            var oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        public T RemoveAtIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы списка");
            }

            if (index == 0)
            {
                return RemoveFirstItem();
            }

            var item = GetItem(index - 1);

            var oldData = item.Next.Data;
            item.Next = item.Next.Next;

            Count--;
            return oldData;
        }

        public bool RemoveByValue(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            var item = _head;

            for (int i = 0; i < Count; i++)
            {
                if (Equals(data, item.Data))
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

            if (_head == null)
            {
                return result;
            }

            var item = _head;
            var newItem = new LinkedListItem<T>(item.Data);
            result._head = newItem;

            for (int i = 0; i < Count; i++)
            {
                newItem.Next = new LinkedListItem<T>(item.Next.Data);
                newItem = newItem.Next;
                item = item.Next;
            }
            result.Count = Count;

            return result;
        }

        public override string ToString()
        {
            if (_head == null)
            {
                return string.Empty;
            }

            var item = _head;
            var result = new StringBuilder($"{item.Data}");

            for (int i = 0; i < Count - 1; i++)
            {
                item = item.Next;
                result.Append($", {item.Data}");
            }

            return result.ToString();
        }

        private LinkedListItem<T> GetItem(int index)
        {
            var item = _head;
            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

    }
}