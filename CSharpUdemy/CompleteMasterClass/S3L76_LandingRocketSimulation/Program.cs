namespace S3L76_LandingRocketSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rocket = new string[] {
                    @"   /\   ",
                    @"  /  \  ",
                    @" /    \ ",
                    @"/______\",
                    @"|      |",
                    @"| NASA |",
                    @"|      |",
                    @"|------|",
                    @"|      |",
                    @"|      |",
                    @"|      |",
                    @"|______|",
                    @"|  ||  |",
                    @"|  ||  |",
                    @"|__||__|",
                    @"  /__\  "
                };
             
            for (int i = 0; i < Console.WindowHeight - 16; i++)
            {
                Console.Clear();
                Console.WriteLine(string.Concat(Enumerable.Repeat("\r\n", i)));
                Console.Write(string.Join("\r\n", rocket));
                Thread.Sleep(500);
            }
            Console.WriteLine();
            Console.WriteLine("The rocket has landed. Woohoo! Another successful landing!");
            Console.ReadKey();
        }
    }
}
