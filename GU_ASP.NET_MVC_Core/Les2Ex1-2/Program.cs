using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Les2Ex1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThreadPool myThreadPool = new MyThreadPool();
            var tasks = new ITask[100];
            var random = new Random();
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(i, random.Next(0, 2));
                Console.WriteLine("Created task {0}", i);
            }

            for (int i = 0; i < 100; i++)
            {
                myThreadPool.QueueUserWorkItem(tasks[i]);
            }
            myThreadPool.Stop();
            myThreadPool.QueueUserWorkItem(tasks[5]);
            myThreadPool.QueueUserWorkItem(tasks[2]);
            Console.WriteLine("Stopped");
            Console.ReadLine();
        }
    }
}
