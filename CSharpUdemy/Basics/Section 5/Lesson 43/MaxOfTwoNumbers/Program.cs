/*
** Write a program which takes two numbers from the console and displays the maximum of the two.
**/

using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        string? firstNumber = Console.ReadLine();
        Console.Write("Enter the second number: ");
        string? secondNumber = Console.ReadLine();
        bool isFirstNumber = int.TryParse(firstNumber, out int first);
        bool isSecondNumber = int.TryParse(secondNumber, out int second);

        if (isFirstNumber && isSecondNumber)
        {
            Console.WriteLine($"Maximum: {Math.Max(first, second)}");
        }
        else
            Console.WriteLine("First or second number were entered in wrong format!");

    }
}