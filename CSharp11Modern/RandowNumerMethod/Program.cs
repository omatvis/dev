namespace RandowNumerMethod;

class Program
{
    static void Main(string[] args)
    {
        outputFiveRandomNumber();
    }

    static void outputFiveRandomNumber() {
        static void DisplayRandomNumbers()
        {
            int seed = Convert.ToInt32((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            Random random = new(seed);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{random.Next(1, 100)}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Generating random numbers:");
        DisplayRandomNumbers();
    }
}
