using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] _items = new T[10];
        private int _length;

        public ArrayList(int capacity)
        {
            _items = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _length; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (_length >= _items.Length)
            {
                IncreaseCapacity();
            }

            _items[_length] = item;
            _length++;
        }

        public void Clear()
        {
            _length = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return _length;
            }
        }

        public bool IsReadOnly { get; }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException("Индекс выходит за границы списка");
            }

            if (index < _length - 1)
            {
                Array.Copy(_items, index+1, _items, index, _length-index-1);
            }
            _length--;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы списка");
                }
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы списка");
                }
                _items[index] = value;
            }
        }

        public void IncreaseCapacity()
        {
            var oldItems = _items;
            _items = new T[oldItems.Length*2];
            Array.Copy(oldItems, 0, _items, 0, oldItems.Length);
        }
    }
}
