using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Les2Ex1_2
{
    class Task : ITask
    {
        int _timeOut;
        public Task(int id, int timeOut)
        {
            Id = id;
            _timeOut = timeOut;
        }

        public int Id { get; }

        public void Execute()
        {
            Thread.Sleep(_timeOut * 1000);
        }
    }
}
