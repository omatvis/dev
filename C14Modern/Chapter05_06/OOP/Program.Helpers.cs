namespace OOP
{
    using System.Globalization; // To use CultureInfo.

    internal partial class Program
    {
        public static void ConfigureConsole(
            string culture = "en-US",
            bool useComputerCulture = false,
            bool showCulture = true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (!useComputerCulture)
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            }

            if (showCulture)
            {
                Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.DisplayName}.");
            }
        }

        public static void PassingParameter(in int x)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"x = {x}");
        }
    }
}