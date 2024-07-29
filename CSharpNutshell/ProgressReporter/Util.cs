namespace ProgressReporter;

public delegate void ProgressReporter (int percentComplete);
public class Util
{
    public static void HardWork(ProgressReporter p)
    {
        for (int i = 0; i < 10; i++)
        {
            p(i * 10); // Invoke delegate
            System.Threading.Thread.Sleep(100); // Simulate hard work
        }
    }
}
