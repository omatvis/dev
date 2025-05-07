using System;

namespace LinqWithObjects
{
    public partial class Program
    {
        private static void SectionTitle(string title)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"*** {title} ***");
            ForegroundColor = previousColor;
        }
    }
}
