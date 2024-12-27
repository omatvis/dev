using System.Collections.Generic;
using System.Globalization;
using System.Text;

class RefLocals
{
    public int SomePublicInt;
}

internal class Program
{
    private static string a = "1";
    private static string b = "2";

    private static void Main(string[] args)
    {
        // Stack and overflow example
        const int x = 115;
        try
        {
            Console.WriteLine($"{x}! = {Factorial(x)}");
        }
        catch (System.OverflowException e)
        {
            Console.WriteLine($"Operation {x}!. {e.Message}");
        }

        // Heap example
        HeapStringBuilder();

        // Passing arguments by value
        int x1 = 8;
        Foo(x1); // Make a copy od x
        Console.WriteLine($"{x1} outside Foo() function"); // x will still be 8

        // passing arguments by refrence
        StringBuilder sb = new StringBuilder("Test");
        Foo(sb);
        Console.WriteLine(sb);

        // Out modifier

        Split("Stevie Ray Vaughn", out a, out b);
        Console.WriteLine(a); // Stevie Ray
        Console.WriteLine(b); // Vaughn

        // In
        string bigText = sb.ToString();
        PrintSomethingBig(in bigText);

        // params modifier
        Sum("Sum: ", 1, 2, 3, 4, 5, 6, 7, 8, 9);

        // Ref locals
        RefLocals refLocals = new RefLocals();
        ref int refSomePublicInt = ref refLocals.SomePublicInt;
        Console.WriteLine(refSomePublicInt);
        refSomePublicInt = 22;
        Console.WriteLine($"{refSomePublicInt} {refLocals.SomePublicInt}");
    }

    // Params modifier
    static void Sum(string label, params int[] numbers)
    {
        Console.WriteLine($"{label} {numbers.Sum(x => x)}");
    }

    // In modifier
    static void PrintSomethingBig(in string bigText)
    {
        Console.WriteLine(bigText);
    }

    // Out modifier
    static void Split(string name, out string firstNames, out string lastName)
    {
        Console.WriteLine($"a = {a}; b = {b}");
        int i = name.LastIndexOf(' ');
        firstNames = name.Substring(0, i);
        lastName = name.Substring(i + 1);
    }

    // Passed by reference
    static void Foo(StringBuilder? fooSB)
    {
        fooSB!.Append("test");
        fooSB = null;
    }

    // Passed by value
    static void Foo(int p)
    {
        p += 1;
        Console.WriteLine($"{p} inside Foo() function");
    }

    // Stack example
    static int Factorial(int x)
    {
        if (x == 0)
            return 1;
        return x * Factorial(x - 1);
    }

    // Heap deallocation
    static void HeapStringBuilder()
    {
        StringBuilder ref1 = new StringBuilder("object1");
        Console.WriteLine(ref1);
        // The StringBuilder referenced by ref1 is now eligible for GC.
        StringBuilder ref2 = new StringBuilder("object2");
        StringBuilder ref3 = ref2;
        // The StringBuilder referenced by ref2 is NOT yet eligible for GC.
        Console.WriteLine(ref3);
        ; // object2
    }
}
