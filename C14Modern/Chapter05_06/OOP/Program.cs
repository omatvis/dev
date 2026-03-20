using System;
using System.Threading;

namespace OOP
{
    internal partial class Program
    {
        public record ImmutableVehicle
        {
            public required int Wheels { get; init; }
            public required string? Color { get; init; }
            public required string? Brand { get; init; }
        }

        static void Main(string[] args)
        {
            ConfigureConsole();

            ImmutableVehicle car = new ImmutableVehicle()
            {
                Brand = "Toyota",
                Color = "Red",
                Wheels = 4
            };

            Console.WriteLine(car);

            int y = 1;

            // a small synchronization helper so we can change y after the thread has started
            using ManualResetEventSlim started = new(false);

            Thread t = new Thread(() =>
            {
                // call the method with 'in y' from inside the thread's lambda
                PassingParameter(in y, started);
            });

            t.Start();

            // wait until the thread signals it has started and read the passed reference
            started.Wait();

            Console.WriteLine("[Main] Sleeping 400 ms then changing y -> 42");
            Thread.Sleep(400);

            // change the original variable while the worker thread is still running
            y = 42;

            Console.WriteLine("[Main] Changed y to 42. Waiting for thread to finish.");
            t.Join();
            Console.WriteLine("[Main] Thread finished.");
        }

        static void PassingParameter(in int x, ManualResetEventSlim started)
        {
            Console.WriteLine($"[Thread] Entered: initial x = {x}");

            // signal the main thread that we've started and observed the initial value
            started.Set();

            // read `x` multiple times with delays to show that changes made by the main thread
            // can be observed by this method (because it's a readonly reference to the original storage).
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"[Thread] Iteration {i}: x = {x}");
                Thread.Sleep(250);
            }

            Console.WriteLine("[Thread] Exiting.");
        }

        static void ConfigureConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
    }
}
