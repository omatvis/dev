namespace ConfigurableInstrumenting;

using System.Diagnostics;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(format: "Reading from appsettings.json in {0}", arg0: Directory.GetCurrentDirectory());
        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        TraceSwitch ts = new(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");
        configuration.GetSection("PacktSwitch").Bind(ts);
        Trace.WriteLineIf(ts.TraceError, "Trace error");
        Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
        Trace.WriteLineIf(ts.TraceInfo, "Trace information");
        Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
    }
}
