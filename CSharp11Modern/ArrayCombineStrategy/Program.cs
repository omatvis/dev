namespace ArrayCombineStrategy;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        string[] values = { "12.3", "45", "ABC", "11", "DEF" };
        string concatString = "";
        decimal sumNumber = 0m;
        foreach (string item in values)
        {
            bool parsed = decimal.TryParse(item, out decimal parsedNumber);
            if (parsed == true) {
                sumNumber += parsedNumber;
            } else {
                concatString = String.Concat(concatString, item);
            }
        }
        Console.WriteLine($"Message: {concatString}");
        Console.WriteLine($"Total: {sumNumber}");
    }
}
