using System;
/*
** Write a program and ask the user to enter a number. 
** The number should be between 1 to 10. 
** If the user enters a valid number, display "Valid" on the console. 
** Otherwise, display "Invalid". 
** (This logic is used a lot in applications where values entered into input boxes need to be validated.)
**/

internal class Program
{
    /// <summary>
    /// Main entry program point
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.Write("Enter a number between 1 and 10: ");
        string? s = Console.ReadLine();
        bool wasParsed = int.TryParse(s, out var result);

        if (wasParsed && result > 0 && result < 11)
        {
            Console.WriteLine("Valid");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}
