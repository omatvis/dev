partial class Program
{
    private static void SectionTitle(string title)
    {
        System.Console.WriteLine();
        System.ConsoleColor previousColor = System.Console.ForegroundColor;
        // Use a color that stands out on your system.
        try
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            System.Console.WriteLine($"*** {title} ***");
        }
        finally
        {
            System.Console.ForegroundColor = previousColor;
        }
    }
}

