using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.Cryptography;
using System.Transactions;

namespace LoopsAndOverflow;

class Program
{
    static void Main(string[] args)
    {
        int max = 500;
        try
        {
            checked
            {
                for (byte i = 0; i < max; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow exception!");
        }

        // Fizz Buzz game
        for (int i = 1; i < 101; i++)
        {
            string word = i switch
            {
                int j when j % 3 == 0 && j % 5 == 0 => "FizzBuzz",
                int j when j % 3 == 0 => "Fizz",
                int j when j % 5 == 0 => "Buzz",
                _ => Convert.ToString(i)
            };
            if (i < 100)
            {
                word = String.Concat(word, ", ");
            }
            Console.Write($"{word}");
        }

        // Handling exception()
        Console.WriteLine("");
        (int a, int b) = (0, 0);
        (string? c, string? d) = (string.Empty, string.Empty);
        try
        {
            Console.Write("Enter a number between 0 and 255:");
            c = Console.ReadLine();
            Console.Write("Enter another number between 0 and 255:");
            d = Console.ReadLine();

            a = Convert.ToInt32(c);
            b = Convert.ToInt32(d);
            Console.WriteLine($"{a} divided by {b} is {a / b}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Input string was not in a correct format.");
        }
    }
}
