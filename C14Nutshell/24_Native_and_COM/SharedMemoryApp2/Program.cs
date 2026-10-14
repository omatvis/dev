namespace SharedMemoryApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SharedMemory.SharedMem sm = new SharedMemory.SharedMem("MyShare", true, 1000))
            {
                IntPtr root = sm.Root;
                // I have the same shared memory!
            }
        }
    }
}
