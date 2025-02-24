using System;
using System.Text;
using PracticeLib;

namespace Practice;

partial class Program
{
    public static void BinaryOperatorComplementRun()
    {
        int a = 0b1;
        string resultComplement = BitwiseOperator.Complement(a);
        Console.WriteLine("Bitwise Complement Operator: ~");
        Console.WriteLine($"~{Convert.ToString(a, 2).PadLeft(32, '0'), 32}");
        Console.WriteLine($"{new string('-', 32), 33}");
        Console.WriteLine($"{resultComplement, 33}");
    }

    public static void IncrementByOneRunPassByValue()
    {
        int x = 5;
        Console.WriteLine(ParametersInMethodTypes.IncrementByValue(x));
        Console.WriteLine(x);
    }

    public static void IncrementByOneRunPassByReference()
    {
        int x = 5;
        Console.WriteLine(x);
        Console.WriteLine(ParametersInMethodTypes.IncrementByReference(ref x));
        Console.WriteLine(x);
    }

    public static void AddByeRun()
    {
        StringBuilder message = new("Hello");
        Console.WriteLine(message);
        ParametersInMethodTypes.AddBye(message);
        Console.WriteLine(message);
    }
}
