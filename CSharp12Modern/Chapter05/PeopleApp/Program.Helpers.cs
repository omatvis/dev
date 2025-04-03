using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; // To use CultureInfo.

internal partial class Program
{
    private static void ConfigureConsole(
        string culture = "en-US",
        bool useComputerCulture = false,
        bool showCulture = true)
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        if (showCulture)
        {
            WriteLine($"Current culture: {CultureInfo.CurrentCulture.
           DisplayName}.");
        }
    }
}



