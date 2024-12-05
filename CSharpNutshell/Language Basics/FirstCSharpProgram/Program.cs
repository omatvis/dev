using System;
internal class Program
{
    private static void Main(string[] args)
    {
        SayHello();

        Console.WriteLine(FeetTotInches(30));
        Console.WriteLine(FeetTotInches(100));

        static int FeetTotInches(int feet) {
            return feet * 12;
        }

        static void SayHello() {
            Console.WriteLine("Hello, world!");
        }
    }
}