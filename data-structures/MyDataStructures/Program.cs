using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyDataStructures.DataStructures;

namespace MyDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<string>();
            myList.Add("Test1");
            myList.Add("Test2");
            myList.Remove(0);

            Console.WriteLine(myList[0]);

            Console.ReadKey();
        }
    }
}
