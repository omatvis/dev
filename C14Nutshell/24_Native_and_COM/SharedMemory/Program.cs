namespace SharedMemory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SharedMem sm = new SharedMem("MyShare", false, 1000))
            {
                IntPtr root = sm.Root;
                // I have shared memory!
                Console.ReadLine();         // Here's where we start a second app...
            }
        }
    }
}
