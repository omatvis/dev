namespace SourceGenerators
{
     internal partial class Program
    {
        static void Main(string[] args)
        {
            ConfigureConsole();
            decimal price = 19.99M;
            DateTimeOffset today = DateTimeOffset.Now;

            Console.WriteLine($"Today, {today:D}, the price is {price:C}.");
        }
    }
}
