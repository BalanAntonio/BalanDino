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
        int altezzaMax, n;
        
        public CDinosauro(CQueue<string> c, CPila<string> p, int a, SemaphoreSlim s)
        {
            coda = c; pila = p; altezzaMax = a; mutex = s; n = 0;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await mutex.WaitAsync();
                if (coda.IsEmpty()) { mutex.Release(); Task.Delay(200); }
                else
                {
                    if (n >= altezzaMax)
                    {
                        Console.WriteLine("Costruito pezzo");
                        for(int i = 0; i < n; i++)
                        {
                            pila.Pop();
                        }
                        n = 0;
                    }
                    mutex.Release();
                    Task.Delay(200);
                    await mutex.WaitAsync();
                    pila.Push(coda.Dequeue());
                    Console.WriteLine("Aggiunto pezzo alla pila");
                    n++;
                    mutex.Release();
                }
                
            }
        }
    }
}
