using System;
using System.Security.Claims;
using ValTypePoint = TypesConversions.ValueTypes.Point;
using RefTypePoint = TypesConversions.ReferenceTypes.Point;

internal class Program
{
    private static void Main(string[] args)
    {
        int x = 12345;
        long y = x; // implicit conversion
        short z = (short)x; // explicit conversion

        System.Console.WriteLine("Value Type Point");
        ValTypePoint p1 = new() { X = 7 };
        ValTypePoint p2 = p1; // copy value

        System.Console.WriteLine($"p1.X = {p1.X}");
        System.Console.WriteLine($"p2.X = {p2.X}");

        p1.X = 9;

        System.Console.WriteLine($"p1.X = {p1.X}");
        System.Console.WriteLine($"p2.X = {p2.X}");

        System.Console.WriteLine("Ref Type Point");
        RefTypePoint p3 = new() { X = 7 };
        RefTypePoint p4 = p3; // copy reference

        System.Console.WriteLine($"p3.X = {p3.X}");
        System.Console.WriteLine($"p4.X = {p4.X}");

        p3.X = 9;

        System.Console.WriteLine($"p3.X = {p3.X}");
        System.Console.WriteLine($"p4.X = {p4.X}");

        System.Console.WriteLine("Null");
        RefTypePoint? p5 = null;
        System.Console.WriteLine($"p5 == null: {p5 == null}");
        try
        {
            System.Console.WriteLine(p5!.X);
        }
        catch (System.NullReferenceException)
        {
            System.Console.WriteLine("p5 is null");
        }

        int b = int.MaxValue;
        try
        {
            b++;
        }
        catch (System.OverflowException)
        {
            System.Console.WriteLine("b integral overflow");
        }
    }
}
