using System;

namespace PracticeLib;

public class ThreadSafe
{
    private static bool done;
    private static readonly object locker = new();

    public static void Go()
    {
        if (!done)
        {
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }
    }
}
