namespace BalanDino
{
    internal class Puntatore<T>
    {
        T valore;
        public T getValore() { return valore; }
        public void setValore(T v) { valore = v; }

        public Puntatore(T v)
        {
            valore = v;
        }
    }
}
