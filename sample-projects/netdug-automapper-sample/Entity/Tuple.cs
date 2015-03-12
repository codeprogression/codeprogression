namespace NETDUGSample.Entity
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        public TFirst First { get; private set; }
        public TSecond Second { get; private set; }
    }
}