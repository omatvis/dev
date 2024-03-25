namespace CardinalToOrdinal;

class Program
{
    static void Main(string[] args)
    {
        RunCardinalToOrdinal();
    }

    static string CardinalToOrdinal(int number)
    {
        int lastTwoDigits = number % 100;
        string ordinalText = lastTwoDigits switch
        {
             >= 11 and <=13 => $"{number:N0}th",
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

    static void RunCardinalToOrdinal()
    {
        for (int i = 0; i < 150; i++)
        {
            Console.WriteLine($"{CardinalToOrdinal(i)}");
        }
    }
}
