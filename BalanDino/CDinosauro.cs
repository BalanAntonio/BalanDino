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
        int altezza;
        
        public CDinosauro(CQueue<string> c, CPila<string> p, int a)
        {
            coda = c; pila = p; altezza = a;
        }
    }
}
