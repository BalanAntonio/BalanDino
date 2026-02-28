using BalanStackQueue;
namespace BalanDino
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int altezzaMax = 5;
            SemaphoreSlim mutexCoda = new SemaphoreSlim(1);
            SemaphoreSlim mutexPila = new SemaphoreSlim(1);

            CQueue<string> coda = new CQueue<string>();
            CPila<string> pila = new CPila<string>();

            CRobot robot = new CRobot(coda, mutexCoda);
            CDinosauro dinosauro = new CDinosauro(coda, pila, altezzaMax, mutexCoda, mutexPila);

            robot.Lavora(); dinosauro.Lavora();

            await Task.Delay(20000);
        }
    }
}
