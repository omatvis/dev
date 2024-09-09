using System.Diagnostics;

partial class Program
{
    private static void Main(string[] args)
    {
        TimesTable(7, 20);
        WriteLine($"You must pay {CalculateTax(amount: 149, twoLetterregionCode: "FR")} in tax.");

        RunFibImperative();
        RunFibFunctional();

        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
        WriteLine($"Writing to: {logPath}");
        TextWriterTraceListener logFile = new(File.CreateText(logPath));
        Trace.Listeners.Add(logFile);
        Trace.AutoFlush = true;
        Debug.WriteLine("Debug says, I am watching");
        Trace.WriteLine("Trace says, I am watching");

        TraceLoggingLevels();
        LogSourceDetails(true);
    }
}
