using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Ex1_2
{
    interface IMyThreadPool
    {
        void QueueUserWorkItem(ITask task);
        void Stop();
    }
}
