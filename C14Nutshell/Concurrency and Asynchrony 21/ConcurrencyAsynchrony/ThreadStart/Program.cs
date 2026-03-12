namespace ThreadStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new(PrintRandomCharacters);
            t.Start();
            Console.WriteLine("A thread has been started from a main thread");
            Thread.Sleep(1);
            Console.WriteLine("The main thread after sleeping during 1 milisecond");
        }

        static void PrintRandomCharacters()
        {
            Random rnd = new(Environment.TickCount);
            int rndInt;
            do
            {
                rndInt = rnd.Next(1001);
                Console.Write(rndInt);
                Console.Write(' ');

            } while (rndInt < 1000);
            Console.WriteLine("At the end of the thread routine execution");
        }
    }
}
