class MyReporter
{
    public string Prefix = "";

    public void ReportProgress(int percentComplete) => Console.WriteLine(Prefix + percentComplete);
}
