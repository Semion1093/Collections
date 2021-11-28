using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDoublyLinkedList<int> list = new MyDoublyLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.RemoveLast();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


        }
    }
}

