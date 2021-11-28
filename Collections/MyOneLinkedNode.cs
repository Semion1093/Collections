using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class LinkedListNode<T> 
    {
        public LinkedListNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T> 
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;
        int count;

        public void AddFirst(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        public void RemoveFirst(T data)
        {
            if (head != null)
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
                count--;

            }
        }

        public int Count { get { return count; } }

        public T this[int index]
        {
            get
            {
                if (index < 0) throw new ArgumentOutOfRangeException();
                LinkedListNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null)
                        throw new ArgumentOutOfRangeException();
                    current = current.Next;
                }
                return current.Data;
            }
        }

        public void Add(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public bool Remove(T data)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {

                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
 
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
