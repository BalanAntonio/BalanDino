using BalanQueueStack;
namespace BalanDino
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int altezzaMax = 5;
            SemaphoreSlim mutex = new SemaphoreSlim(1);
            CQueue<string> coda = new CQueue<string>();
            CPila<string> pila = new CPila<string>();

            CRobot robot = new CRobot(coda, mutex);
            CDinosauro dinosauro = new CDinosauro(coda, pila, altezzaMax, mutex);

            robot.Lavora(); dinosauro.Lavora();
        }
    }
}
