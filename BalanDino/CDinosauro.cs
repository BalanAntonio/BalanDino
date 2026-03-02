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
        SemaphoreSlim mutexCoda;
        SemaphoreSlim mutexPila;
        int altezzaMax;
        Puntatore<int> n;
        
        public CDinosauro(CQueue<string> c, CPila<string> p, int a, SemaphoreSlim sC, SemaphoreSlim sP, Puntatore<int> P)
        {
            coda = c; pila = p; altezzaMax = a; mutexCoda = sC;mutexPila=sP ; n = P;
        }

        public async Task Lavora()
        {
            while (true)
            {
                await mutexCoda.WaitAsync();
                if (coda.IsEmpty())
                {
                    mutexCoda.Release();
                    await Task.Delay(200);
                    continue;
                }

                string pezzo = coda.Dequeue();
                mutexCoda.Release();

                await mutexPila.WaitAsync();
                try
                {
                    pila.Push(pezzo);
                    n.setValore(n.getValore() + 1);
                    Console.WriteLine("Aggiunto pezzo alla pila");

                    if (n.getValore() >= altezzaMax)
                    {
                        Console.WriteLine("Costruito portale");

                        for (int i = 0; i < n.getValore(); i++)
                        {
                            pila.Pop();
                        }

                        n.setValore(0);
                    }
                }
                finally
                {
                    mutexPila.Release();
                }

                await Task.Delay(200);
            }
        }
    }
}
