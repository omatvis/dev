namespace DataTypeCasting;

class Program
{
    static void Main(string[] args)
    {
        // Implicit conversion
        int first = 2;
        string second = "4";
        string result = first + second;
        Console.WriteLine(result);

        int myInt = 3;
        Console.WriteLine($"int {myInt}");

        decimal myDecimal = myInt;
        Console.WriteLine($"decimal: {myDecimal}");

        decimal myDecimalTwo = 3.14m;
        Console.WriteLine($"decimal: {myDecimalTwo}");

        // Explicit converting
        int myIntTwo = (int)myDecimal;
        Console.WriteLine($"int: {myIntTwo}");

        decimal myDecimalThree = 1.23456789m;
        float myFloat = (float)myDecimalThree;

        Console.WriteLine($"Decimal: {myDecimalThree}");
        Console.WriteLine($"Float  : {myFloat}");

        // Convert
        int firstConvert = 5;
        int secondConvert = 7;
        string message = firstConvert.ToString() + secondConvert.ToString();
        Console.WriteLine(message);

        string firstParse = "5";
        string secondParse = "7";
        int sum = int.Parse(firstParse) + int.Parse(secondParse);
        Console.WriteLine(sum);

        string value1 = "5";
        string value2 = "7";
        int resultToInt32 = Convert.ToInt32(value1) * Convert.ToInt32(value2);
        Console.WriteLine(resultToInt32);

        int value = (int)1.5m; // casting truncates
        Console.WriteLine(value);

        int value21 = Convert.ToInt32(1.5m); // converting rounds up
        Console.WriteLine(value21);

        // TryParse
        string tryParseValue = "102";
        int tryParseResult = 0;
        if (int.TryParse(tryParseValue, out tryParseResult))
        {
            Console.WriteLine($"Measurement: {tryParseResult}");
        }
        else
        {
            Console.WriteLine("Unable to report the measurement.");
        }
        Console.WriteLine($"Measurement (w/ offset): {50 + tryParseResult}");
    }
}
