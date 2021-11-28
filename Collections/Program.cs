using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> mylist = new MyList<int>();

            //mylist.Add(1);
            //mylist.Add(2);
            //mylist.Add(3);
            //mylist.Add(4);
            //mylist.Add(5);
            //mylist.Add(6);

            //mylist.Remove(1);

            //for (int i = 0; i < mylist.Count; i++)
            //{
            //    int item = mylist[i];
            //    Console.Write(item);

            MyLinkedListNode mylistnode = new MyLinkedListNode();

            mylistnode.Add(1);
            mylistnode.Add(2);
            mylistnode.Add(3);
            mylistnode.Add(4);

            foreach (var item in mylistnode)
            {
                Console.WriteLine(item);
            }

        }
    }
}

