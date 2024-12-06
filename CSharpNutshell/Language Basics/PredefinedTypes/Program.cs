using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int x = 12 * 30;

        string message = "Hello world";
        string upperMessage = message.ToUpper();
        Console.WriteLine(upperMessage);

        x = 2022;
        message += x.ToString();
        Console.WriteLine(message);

        bool simpleVar = false;
        if (simpleVar) {
            Console.WriteLine("This will not print!");
        }

        x = 5000;
        bool lessThenAMile = x < 5280;
        if (lessThenAMile) {
            System.Console.WriteLine("This will print!");
        }
    }
}