namespace UnsafePonters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 100;
            unsafe
            {
                int* ptr = &x;
                *ptr = 1;
                Console.WriteLine(x);
                Console.ReadKey();
            }
        }
    }
}
