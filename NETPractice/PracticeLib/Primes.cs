using System;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeLib;
public class Primes
{
    public int GetPrimesCount(int start, int count)
    {
        return
            ParallelEnumerable.Range(start, count).Count(n =>
               Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
    }

    public static Task<int> GetPrimesCountAsync(int start, int count)
    {
        Console.WriteLine($"At the beginning of GetPrimesCountAsync: {DateTime.UtcNow}");
        return Task.Run(() => {
            Console.WriteLine($"Inside GetPrimesCountAsync.Task.Run: {DateTime.UtcNow}");
            return
                ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
            }
        );       
    }

}
