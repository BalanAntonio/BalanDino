using BalanQueueStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanDino
{
    internal class CRobot
    {
        CQueue<string> coda;
        SemaphoreSlim mutex;

        public CRobot(CQueue<string> c, SemaphoreSlim s)
        {
            coda = c; mutex = mutex;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await Task.Delay(Random.Shared.Next(100, 1001));
                await mutex.WaitAsync();
                coda.Enqueue("qwertyuiop");
                mutex.Release();
            }
        }
    }
}
