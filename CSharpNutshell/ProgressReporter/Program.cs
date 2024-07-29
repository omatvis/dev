namespace ProgressReporter;

internal class Program
{
    private static void Main(string[] args)
    {
        ProgressReporter p = WriteProgressToConsole;
        p += WriteProgressToFile;
        Util.HardWork(p);

        void WriteProgressToConsole(int percentComplete)
        {
            Console.WriteLine(percentComplete);
        }

        void WriteProgressToFile(int percentComplete) {
            StreamWriter textWriter;
            if (File.Exists("progress.txt") == true)
            {
                textWriter = File.AppendText("progress.txt");
            }
            else
            {
                textWriter = File.CreateText("progress.txt");
            }

            textWriter.WriteLine(percentComplete.ToString());
            textWriter.Close();
        }
        ;
    }
}
