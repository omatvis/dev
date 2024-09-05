using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        for (int i = 1; i <= size; i++)
        {
            WriteLine($"{i} x {number} = {i * number}");
        }
    }

    static decimal CalculateTax(decimal amount, string twoLetterregionCode)
    {
        decimal rate = twoLetterregionCode switch
        {
            "CH" => 0.08M,
            "DK" or "NO" => 0.25M,
            "GB" or "FR" => 0.2M,
            "HU" => 0.27M,
            "OR" or "AK" or "MT" => 0.0M,
            "ND" or "WE" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M,
            _ => 0
        };
        return amount * rate;
    }

    static void RunFibImperative()
    {
        for (int i = 1; i < 30; i++)
        {
            WriteLine(
                "The {0} term of Fibonacci sequence is {1:N0}.",
                arg0: i,
                arg1: FibImperative(term: i)
            );
        }
    }

    static int FibImperative(int term)
    {
        if (term == 1)
        {
            return 0;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }

    static int FibFunctional(int term) =>
        term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2),
        };

    static void RunFibFunctional()
    {
        for (int i = 1; i < 30; i++)
        {
            WriteLine(
                "The {0} term of Fibonacci sequence is {1:N0}.",
                arg0: i,
                arg1: FibFunctional(term: i)
            );
        }
    }

    static void TraceLoggingLevels()
    {
        WriteLine("Reading from appsettings.json in {0}", arg0: Directory.GetCurrentDirectory());
        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        TraceSwitch ts =
            new(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");
        configuration.GetSection("PacktSwitch").Bind(ts);
        Trace.WriteLineIf(ts.TraceError, "Trace error");
        Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
        Trace.WriteLineIf(ts.TraceInfo, "Trace info");
        Trace.WriteLineIf(ts.TraceVerbose, "Trace Verbose");
        ReadLine();
    }

    static void LogSourceDetails(
        bool condition,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0,
        [CallerArgumentExpression(nameof(condition))] string callerArgumentExpression = ""
    )
    {
        Trace.WriteLine(
            string.Format(
                "[{0}]\n {1} on line {2}. Expression {3}",
                callerFilePath,
                callerName,
                callerLineNumber,
                callerArgumentExpression
            )
        );
    }
}
