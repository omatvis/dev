namespace CardinalToOrdinal;

class Program
{
    static void Main(string[] args)
    {
        //hot reload testing
        RunCardinalToOrdinal();
    }

    /// <summary>
    /// Converts cardinal to ordinal number, 1 -> 1st etc.
    /// </summary>
    /// <param name="number">cardinal number</param>
    /// <returns>string ordinal number</returns>
    static string CardinalToOrdinal(int number)
    {
        int lastTwoDigits = number % 100;
        string ordinalText = lastTwoDigits switch
        {
            >= 11 and <= 13 => $"{number:N0}th",
            _
                => (number % 10) switch
                {
                    1 => $"{number:N0}st",
                    2 => $"{number:N0}nd",
                    3 => $"{number:N0}rd",
                    _ => $"{number:N0}th"
                }
        };

        return ordinalText;
    }

    static async void RunCardinalToOrdinal()
    {
        for (int i = 0; i < 150; i++)
        {
            Console.WriteLine($"{CardinalToOrdinal(i)}");
        }
        while (true)
        {
            Console.WriteLine("Hot Reloading Testing");
            await Task.Delay(2000);
        }
    }
}
