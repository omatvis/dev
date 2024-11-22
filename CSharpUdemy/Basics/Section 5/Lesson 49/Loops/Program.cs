using System;

internal class Program
{
    private static void Main(string[] args)
    {
        CountOfDivisibleBy3();
        SumOfEnteredNumbers();
        Factorial();
        GuessNumber();
        FindMaximumWithinSequenceOfNumbers();
    }

    /// <summary>
    /// Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder.
    /// Display the count on the console.
    /// </summary>
    public static void CountOfDivisibleBy3()
    {
        var cnt = 0;
        for (int i = 1; i <= 100; i++)
        {
            cnt += (i % 3 == 0) ? 1 : 0;
        }
        Console.WriteLine(cnt);
    }

    /// <summary>
    /// Write a program and continuously ask the user to enter a number or "ok" to exit.
    /// Calculate the sum of all the previously entered numbers and display it on the console.
    /// </summary>
    public static void SumOfEnteredNumbers()
    {
        var sum = 0;
        do
        {
            Console.Write("Enter a number or OK to exit: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;
            if (input == "OK")
                break;
            var number = int.Parse(input);
            sum += number;
        } while (true);
        Console.WriteLine($"Sum of entered numbers: {sum}");
    }

    /// <summary>
    /// Write a program and ask the user to enter a number.
    /// Compute the factorial of the number and print it on the console.
    /// For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
    /// </summary>
    public static void Factorial()
    {
        Console.WriteLine("Enter a number of factorial: ");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
            return;
        var number = int.Parse(input);
        if (number == 0)
        {
            Console.WriteLine($"0!={1}");
        }
        var factorial = 1;
        for (int i = number; i > 0; i--)
        {
            factorial *= i;
        }
        Console.WriteLine($"{number}!={factorial}");
    }

    /// <summary>
    /// Write a program that picks a random number between 1 and 10.
    /// Give the user 4 chances to guess the number.
    /// If the user guesses the number, display “You won";
    /// otherwise, display “You lost".
    /// (To make sure the program is behaving correctly, you can display the secret number on the console first.)
    /// </summary>
    public static void GuessNumber()
    {
        var random = new Random();
        var randomInt = random.Next(1, 10);
        const int MaxGuessesCount = 4;
        var guessesCount = 1;
        do
        {

            Console.Write("Guess a number: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;
            var number = int.Parse(input);
            if (randomInt == number) {
                Console.WriteLine("You won!");
                break;
            }
            ++guessesCount;            
        } while (guessesCount <= MaxGuessesCount);
        if (guessesCount > MaxGuessesCount) Console.WriteLine("You lost!");
    }

    /// <summary>
    /// Write a program and ask the user to enter a series of numbers separated by comma.
    /// Find the maximum of the numbers and display it on the console.
    /// For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
    /// </summary>
    public static void FindMaximumWithinSequenceOfNumbers() {
        Console.Write("Enter a searie of integral numbers separated by comma: ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;
        string[] series = input.Split(',');
        var maxNumber = int.MinValue;
        foreach (var item in series)
        {
            var element = int.Parse(item);
            if (element > maxNumber) {
                maxNumber = element;
            }
        }
        Console.WriteLine($"Max Number is the sequence: {maxNumber}");
    }
}
