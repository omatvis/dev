namespace SizeOfPrimitives;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(new string('-', 95));
        Console.WriteLine($"{"Type", -10}{"Byte(s) of memory", -17}{"Min", 34}{"Max", 34}");
        Console.WriteLine(new string('-', 95));
        Console.WriteLine($"{"sbyte", -10}{sizeof(sbyte), -17}{sbyte.MinValue, 34}{sbyte.MaxValue, 34}");
        Console.WriteLine($"{"byte", -10}{sizeof(byte), -17}{byte.MinValue, 34}{byte.MaxValue, 34}");
        Console.WriteLine($"{"short", -10}{sizeof(short), -17}{short.MinValue, 34}{short.MaxValue, 34}");
        Console.WriteLine($"{"ushort", -10}{sizeof(ushort), -17}{ushort.MinValue, 34}{ushort.MaxValue, 34}");
        Console.WriteLine($"{"int", -10}{sizeof(int), -17}{int.MinValue, 34}{int.MaxValue, 34}");
        Console.WriteLine($"{"uint", -10}{sizeof(uint), -17}{uint.MinValue, 34}{uint.MaxValue, 34}");
        Console.WriteLine($"{"long", -10}{sizeof(long), -17}{long.MinValue, 34}{long.MaxValue, 34}");
        Console.WriteLine($"{"ulong", -10}{sizeof(ulong), -17}{ulong.MinValue, 34}{ulong.MaxValue, 34}");
        Console.WriteLine($"{"float", -10}{sizeof(float), -17}{float.MinValue, 34}{float.MaxValue, 34}");
        Console.WriteLine($"{"double", -10}{sizeof(double), -17}{double.MinValue, 34}{double.MaxValue, 34}");
        Console.WriteLine($"{"decimal", -10}{sizeof(decimal), -17}{decimal.MinValue, 34}{decimal.MaxValue, 34}");
        Console.WriteLine(new string('-', 95));
    }
}
