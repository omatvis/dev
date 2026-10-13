using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Ordering pizza...");

        var pizzaTask = PreparePizzaAsync();

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine("Waiting for pizza...");
            await Task.Delay(1000); // wait for 1 second
        }

        await pizzaTask;
        Console.WriteLine("Pizza received!");
    }

    static async Task PreparePizzaAsync()
    {
        Console.WriteLine("Pizza is being prepared...");

        await Task.Delay(5000); // wait for 5 seconds

        Console.WriteLine("Pizza is ready.");
    }
}