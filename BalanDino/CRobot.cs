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
        SemaphoreSlim mutexCoda;

        public CRobot(CQueue<string> c, SemaphoreSlim sC)
        {
            coda = c; mutexCoda = sC;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await Task.Delay(Random.Shared.Next(100, 1001));
                await mutexCoda.WaitAsync();
                coda.Enqueue("pezzo");
                Console.WriteLine("Pezzo aggiunto alla coda");
                mutexCoda.Release();
            }
        }
    }
}
