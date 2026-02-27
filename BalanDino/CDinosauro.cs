using BalanQueueStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanDino
{
    internal class CDinosauro
    {
        CQueue<string> coda;
        CPila<string> pila;
        SemaphoreSlim mutex;
        int altezzaMax;
        
        public CDinosauro(CQueue<string> c, CPila<string> p, int a, SemaphoreSlim s)
        {
            coda = c; pila = p; altezzaMax = a; mutex = s;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await mutex.WaitAsync();
                if (coda.IsEmpty()) { mutex.Release(); Task.Delay(200); }
                else
                {
                    mutex.Release();
                    Task.Delay(200);
                    await mutex.WaitAsync();
                    pila.Push(coda.Dequeue());
                    mutex.Release();
                }
                
            }
        }
    }
}
