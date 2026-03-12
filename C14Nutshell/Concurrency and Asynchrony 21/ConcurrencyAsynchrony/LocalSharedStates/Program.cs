using System.Diagnostics;

namespace LocalSharedStates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();
            Thread.CurrentThread.Name = "MainThread";
            // shared variable
            string sharedVariable = Thread.CurrentThread.Name;

            // local name variable has a ThreadStart function scope
            // so every thread main, thread1 and thread2 creates it's own copy of name instance
            
            ThreadStart ts = () => {
                sharedVariable = Thread.CurrentThread.Name;
                Console.WriteLine($"{sw.Elapsed.Microseconds}: Thread: {Thread.CurrentThread.Name} " +
                    $"Shared: {nameof(sharedVariable)}, Value: {sharedVariable}");
                String name = "locals"; 
                Console.WriteLine($"{sw.Elapsed.Microseconds} {typeof(string)} {sizeof(int)} {nameof(name)}"); 
            };
            Thread ts1 = new Thread(ts);
            ts1.Name = "Thread1";
            Thread ts2 = new Thread(ts);
            ts2.Name = "Thread2";
            
            ts1.Start();
            ts2.Start();
            ts();
        }
    }
}
