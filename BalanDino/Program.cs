using BalanQueueStack;
namespace BalanDino
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const int altezzaMax = 5;
            const int nRobot     = 3;
            const int nDino      = 2;


            SemaphoreSlim mutexCoda = new SemaphoreSlim(1);
            SemaphoreSlim mutexPila = new SemaphoreSlim(1);

            Puntatore<int> N = new Puntatore<int>(0);

            CQueue<string> coda = new CQueue<string>();
            CPila<string> pila = new CPila<string>();



            CRobot[] robot = new CRobot[nRobot];
            for (int i = 0; i < nRobot; i++)
            {
                robot[i] = new CRobot(coda,mutexCoda);
                robot[i].Lavora();
            }



            CDinosauro[] dinosauri = new CDinosauro[nDino];
            for (int i = 0; i < nDino; i++)
            {
                dinosauri[i] = new CDinosauro(coda,pila,altezzaMax,mutexCoda,mutexPila,N);
                dinosauri[i].Lavora();
            }

            /*

            CRobot robot = new CRobot(coda, mutexCoda);
            CDinosauro dinosauro = new CDinosauro(coda, pila, altezzaMax, mutexCoda, mutexPila,N);

            robot.Lavora(); dinosauro.Lavora();*/

            await Task.Delay(20000);
        }
    }
}
