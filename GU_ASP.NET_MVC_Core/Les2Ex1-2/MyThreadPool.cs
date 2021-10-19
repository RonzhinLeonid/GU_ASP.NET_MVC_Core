using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Les2Ex1_2
{
    public class MyThreadPool: IMyThreadPool
    {
        int _countThreads;
        readonly Thread[] _threads;
        readonly ConcurrentQueue<ITask> _queue;
        volatile bool _isStopped;

        public MyThreadPool(int countThreads)
        {
            _countThreads = countThreads;
            _threads = new Thread[countThreads];
            _queue = new ConcurrentQueue<ITask>();

            for (var i = 0; i < countThreads; i++)
            {
                _threads[i] = new Thread(ConsumeTask) { Name = $"My Thread Pool thread No{i}" };
                _threads[i].Start();
            }
        }

        public MyThreadPool() : this(Environment.ProcessorCount) { }

        public void QueueUserWorkItem(ITask task)
        {
            if (!_isStopped)
            {
                _queue.Enqueue(task);
            }
          }

        private void ConsumeTask()
        {
            while (true)
            {
                ITask result;
                try
                {
                    if (_queue.Any())
                    {
                        _queue.TryDequeue(out result);
                        Console.WriteLine("task {0}, thread {1}", result.Id, Thread.CurrentThread.Name);
                        result.Execute();
                    }
                }
                catch (InvalidOperationException) { }
            }
        }

        public void Stop()
        {
            if (_isStopped) return;

            _isStopped = true;

            foreach (var t in _threads)
            {
                t.Join();
            }
        }
    }
}
