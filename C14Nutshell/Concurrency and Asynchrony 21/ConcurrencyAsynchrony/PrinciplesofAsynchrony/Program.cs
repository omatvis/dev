using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrinciplesofAsynchrony
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Task<int> GetPrimesCountAsync(int start, int count)
            {
                return Task.Run( () =>
                  ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            }

            async Task DisplayPrimeCounts()
            {
                for (int i = 0; i < 10; i++)
                    Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
                      " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
                Console.WriteLine("Done!");
            }

            await DisplayPrimeCounts();
        }
    }
}
