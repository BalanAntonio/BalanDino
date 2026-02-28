using BalanStackQueue;
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
        SemaphoreSlim mutexCoda;
        SemaphoreSlim mutexPila;
        int altezzaMax, n;
        
        public CDinosauro(CQueue<string> c, CPila<string> p, int a, SemaphoreSlim sC, SemaphoreSlim sP)
        {
            coda = c; pila = p; altezzaMax = a; mutexCoda = sC;mutexPila=sP ; n = 0;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await mutexCoda.WaitAsync();
                if (coda.IsEmpty()) { mutexCoda.Release(); Task.Delay(200); }
                else
                {
                    mutexCoda.Release();
                    if (n >= altezzaMax)
                    {
                        await mutexPila.WaitAsync();
                        Console.WriteLine("Costruito portale");
                        for(int i = 0; i < n; i++)
                        {
                            pila.Pop();
                        }
                        n = 0;
                        mutexPila.Release();
                    }
                    Task.Delay(200);
                    await mutexPila.WaitAsync();
                    pila.Push(coda.Dequeue());
                    Console.WriteLine("Aggiunto pezzo alla pila");
                    n++;
                    mutexPila.Release();
                }
                
            }
        }
    }
}
