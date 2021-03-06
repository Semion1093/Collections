using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class MyList<T> : IList<T>
    {
        T[] _array;
        int _size;
        int _capacity;

        public MyList()
        {
            _array = new T[0];
            _size = 0;
            _capacity = 0;
        }

        public MyList(int capacity)
        {
            _array = new T[capacity];
            _size = 0;
            _capacity = capacity;
        }

        public MyList(T[] colection)
        {
            _array = new T[colection.Length];
            _size = colection.Length;
            _capacity = colection.Length;

            for (int i = 0; i < colection.Length; i++)
                _array[i] = colection[i];
        }

        public int Count => _size;

        public int Capasity => _capacity;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                _array[index] = value;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_size < _capacity)
            {
                _array[_size] = item;
                _size++;
            }
            else
            {
                T[] tmpArray = new T[(int)(_capacity * 1.1 + 1)];
                for (int i = 0; i < _size; i++)
                {
                    tmpArray[i] = _array[i];
                }
                tmpArray[_size] = item;

                _array = tmpArray;
                _size++;
                _capacity = tmpArray.Length;
            }
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; ++i)
                array[i + arrayIndex] = _array[i];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (_array.GetEnumerator() as IEnumerator<T>);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            int pos = -1;
            for (int i = 0; i < _size; i++)
            {
                if (_array.Equals(item))
                    pos = i;
                break;
            }
            return pos;
        }

        public void Insert(int index, T item)
        {
            if (index <= 0 && index >= Count)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");

            else if (_size < _capacity)
            {
                T[] tmpArray = new T[_size + 1];

                for (int i = 0; i < index; i++)
                {
                    tmpArray[i] = _array[i];
                }

                tmpArray[index] = item;

                for (int i = index; i < _size; i++)
                {
                    tmpArray[i + 1] = _array[i];
                }

                _array = tmpArray;
                _size++;
                _capacity = tmpArray.Length;
            }
            else
            {
                T[] tmpArray = new T[(int)(_capacity * 1.1 + 1)]; ;

                tmpArray[index] = item;

                for (int i = 0; i < index; i++)
                {
                    tmpArray[i] = _array[i];
                }

                for (int i = index; i < _size; i++)
                {
                    tmpArray[i + 1] = _array[i];
                }

                _array = tmpArray;
                _size++;
                _capacity = tmpArray.Length;
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_array[i].Equals(item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    _size--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index <= 0 && index >= Count)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");

            else
            {
                T[] tmpArray = new T[_size - 1];

                for (int i = 0; i < index; i++)
                    tmpArray[i] = _array[i];
                for (int i = index + 1; i < _size; i++)
                    tmpArray[i - 1] = _array[i];

                _array = tmpArray;
                _size--;
                _capacity = tmpArray.Length;
            }
        }

        public T[] ToArray()
        {
           T[] array = new T[_array.Length];
            _array.CopyTo(array, 0);
            return array;
        }

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            if (comparer == null)

                throw new InvalidOperationException("Не сравниваемый тип");

            int left = index;

            int right = index + count;

            while (left <= right)

            {
                var middle = (left + right) / 2;

                if (comparer.Compare(item, _array[middle]) == 0)

                    return middle;

                if (comparer.Compare(item, _array[middle]) < 0)

                    right = middle - 1;

                else

                    left = middle + 1;

            }
            return -1;
        }

        public void AddToFront(T item)
        {
            if (_size < _capacity)
            {
                T[] tmpArray = new T[_size + 1];

                tmpArray[0] = item;

                for (int i = 0; i < _size; i++)
                {
                    tmpArray[i + 1] = _array[i];
                }

                _array = tmpArray;
                _size++;
                _capacity = tmpArray.Length;
            }
            else
            {
                T[] tmpArray = new T[(int)(_capacity * 1.1 + 1)];

                tmpArray[0] = item;

                for (int i = 0; i < _size; i++)
                {
                    tmpArray[i + 1] = _array[i];
                }

                _array = tmpArray;
                _size++;
                _capacity = tmpArray.Length;
            }
        }

        public void RemoveFromFront()
        {
            T[] tmpArray = new T[_size - 1];

            for (int i = 1; i < _size; i++)
                tmpArray[i - 1] = _array[i];

            _array = tmpArray;
            _size--;
            _capacity = tmpArray.Length;
        }

        public void RemoveFromEnd()
        {
            T[] tmpArray = new T[_size - 1];

            for (int i = 0; i < _size - 1; i++)
                tmpArray[i] = _array[i];

            _array = tmpArray;
            _size--;
            _capacity = tmpArray.Length;
        }

        public void Reverse()
        {
            for (int i = 0; i < _size / 2; i++)
            {
                T tmp = _array[i];
                _array[i] = _array[_array.Length - i - 1];
                _array[_array.Length - i - 1] = tmp;
            }
        }

        public int FirstIndexByValue(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_array[i].Equals(item))
                    return i;
                break;
            }
            return -1;
        }
    }
}

