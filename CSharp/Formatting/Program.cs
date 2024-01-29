namespace Formatting;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        // Composite formatting
        string first = "Hello";
        string second = "World";
        string result = string.Format("{0} {1}", first, second);
        Console.WriteLine(result);
        Console.WriteLine("{1} {0} {1}!", first, second);
        Console.WriteLine("{0} {0} {0}!", first, second);

        // String interpolation

        Console.WriteLine($"{first} {second}!");
        Console.WriteLine($"{second} {first}!");
        Console.WriteLine($"{first} {first} {first}!");

        // Formatting currency
        decimal price = 123.35m;
        int discount = 50;
        Console.WriteLine($"Price: {price:C} (Save {discount:C})");

        // Formatting numbers
        decimal measurement = 123456.78912m;
        Console.WriteLine($"Measurement: {measurement:N4} units");

        // Formatting percentage
        decimal tax = .36785m;
        Console.WriteLine($"Tax rate: {tax:P2}");

        // Combining formatting approaches
        price = 67.55m;
        decimal salePrice = 59.99m;

        string yourDiscount = String.Format(
            "You saved {0:C2} off the regular {1:C2} price. ",
            price - salePrice,
            price
        );

        yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; //inserted
        Console.WriteLine(yourDiscount);
    }
}
