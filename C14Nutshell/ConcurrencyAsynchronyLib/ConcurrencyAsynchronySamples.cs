namespace ConcurrencyAsynchronyLib
{
    public static class ConcurrencyAsynchronySamples
    {
        public static void CreatingThread()
        {
            Thread t = new Thread(WriteYesHundredTimes);
            t.Start();

            // keep doing something in the main thread
            for (int i = 0; i < 100; i++) Console.WriteLine($"x = {i} No");

            void WriteYesHundredTimes()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"y = {i} Yes");
                }
            }
        }
    }
}
