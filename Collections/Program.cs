using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> mylist = new MyList<int>();

            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(4);
            mylist.Insert(1, 0);

            for (int i = 0; i < mylist.Count; i++)
            {
                int item = mylist[i];
                Console.Write(item);
            }
        }
    }
}
