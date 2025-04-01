namespace Instrumenting;

using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
        Console.WriteLine($"Writing to: {logPath}");
        TextWriterTraceListener logFile = new(File.CreateText(logPath));
        Trace.Listeners.Add(logFile);
        Trace.AutoFlush = true;
        Debug.WriteLine("Debug Message");
        Trace.WriteLine("Trace Message");
    }
}
