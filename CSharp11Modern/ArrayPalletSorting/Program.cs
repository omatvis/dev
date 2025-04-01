namespace ArrayPalletSorting;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        string[] pallets = ["B14", "A11", "B12", "A13"];

        Console.WriteLine("Sorted...");
        Array.Sort(pallets);
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }
        Console.WriteLine("");
        Console.WriteLine("Reversed...");
        Array.Reverse(pallets);
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }

        string[] palletsClear = ["B14", "A11", "B12", "A13"];
        Console.WriteLine();

        Console.WriteLine($"Before: {palletsClear[0].ToLower()}");
        Array.Clear(palletsClear, 0, 2);
        if (palletsClear[0] != null)
            Console.WriteLine($"After: {palletsClear[0].ToLower()}");

        Console.WriteLine($"Clearing 2 ... count: {palletsClear.Length}");
        foreach (var item in palletsClear)
        {
            Console.WriteLine($"--  {item}");
        }

        Console.WriteLine("");
        Array.Resize(ref palletsClear, 6);
        Console.WriteLine($"Resizing 6 ... count: {palletsClear.Length}");

        palletsClear[4] = "C01";
        palletsClear[5] = "C02";

        foreach (var pallet in palletsClear)
        {
            Console.WriteLine($"-- {pallet}");
        }

        Console.WriteLine("");
        Array.Resize(ref palletsClear, 3);
        Console.WriteLine($"Resizing 3 ... count: {palletsClear.Length}");

        foreach (var pallet in palletsClear)
        {
            Console.WriteLine($"-- {pallet}");
        }

        string value = "abc123";
        char[] valueArray = value.ToCharArray();
        Array.Reverse(valueArray);
        string result = new(valueArray);
        Console.WriteLine(result);
        string resultJoin = String.Join(",", valueArray);
        Console.WriteLine(resultJoin);
        string[] items = resultJoin.Split(',');
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }
}
