using System.Security.Cryptography;

namespace Learn;

class Program
{
    static void Main(string[] args)
    {   // Loop from 1 to 100 implementing IEnumerable and IEnumerator
        ArtificialSequence seq = new();
        foreach (int item in seq)
        {
            Console.WriteLine(item);
        }
    }
}