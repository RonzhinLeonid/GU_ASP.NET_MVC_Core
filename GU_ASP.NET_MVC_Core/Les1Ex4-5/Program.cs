using MyLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Les1Ex4_5
{
    class Program
    {
        static ListWrapper<int> list = new ListWrapper<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Thread thread;
            for (int i = 0; i < 5; i++)
            {
                thread = new Thread(new ThreadStart(() => AddListTestMethod(2000)));
                thread.Start();
            }
            thread = new Thread(new ThreadStart(() => RemoveListTestMethod(5)));
            thread.Start();
            Thread.Sleep(11000);

            Console.WriteLine("Stop");

        }

        private static void AddListTestMethod(int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
                Console.WriteLine($"{i} in {Thread.CurrentThread.ManagedThreadId}");
                //Thread.Sleep(100);
            }
        }
        private static void RemoveListTestMethod(int value)
        {
            list.Remove(value);
            //Thread.Sleep(100);
        }
    }
}
