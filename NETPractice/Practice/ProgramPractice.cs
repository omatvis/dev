using System;
using System.Text;
using PracticeLib;
using PracticeLib.VarianceType;
using PracticeLib.Generics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Practice
{
    partial class Program
    {

        public static void BinaryOperatorComplementRun()
        {
            int a = 0b1;
            string resultComplement = BitwiseOperator.Complement(a);
            Console.WriteLine("Bitwise Complement Operator: ~");
            Console.WriteLine($"~{Convert.ToString(a, 2).PadLeft(32, '0'),32}");
            Console.WriteLine($"{new string('-', 32),33}");
            Console.WriteLine($"{resultComplement,33}");
        }

        public static void IncrementByOneRunPassByValue()
        {
            int x = 5;
            Console.WriteLine(ParametersInMethodTypes.IncrementByValue(x));
            Console.WriteLine(x);
        }

        public static void IncrementByOneRunPassByReference()
        {
            int x = 5;
            Console.WriteLine(x);
            Console.WriteLine(ParametersInMethodTypes.IncrementByReference(ref x));
            Console.WriteLine(x);
        }

        public static void AddByeRun()
        {
            StringBuilder message = new("Hello");
            Console.WriteLine(message);
            ParametersInMethodTypes.AddBye(message);
            Console.WriteLine(message);
        }

        public static void StackRun()
        {
            PracticeLib.Generics.Stack<int> stack = new();
            stack.Push(5);
            stack.Push(10);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        public static void VarianceRun()
        {
            PracticeLib.Generics.Stack<Bear> bearStack = new();
        }

        private delegate int Transformer(int x);

        public static void DelegateRun()
        {
            static int Square(int x) => x * x;
            Transformer transformer = new(Square);
            int result = transformer.Invoke(3);
            Console.WriteLine(result);
        }

        public static void DelegatePlugInRun()
        {
            int[] values = { 1, 2, 3 };
            Transform(values, Square);
            Output(values);
            Transform(values, Sqrt);
            Output(values);
            Transform(values, Cube);
            Output(values);

            int Square(int x) => x * x;
            int Sqrt(int x) => (int)Math.Sqrt(x);
            int Cube(int x) => x * x * x;
            static void Transform(int[] values, Transformer t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
            static void Output(int[] values)
            {
                foreach (int i in values)
                    Console.Write(i + " "); // 1 4 9
            }
        }

        private delegate void ProgressReporter(int percentComplete);

        private static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10); // Invoke delegate
                System.Threading.Thread.Sleep(100); // Simulate hard work
            }
        }

        public static void HardWorkRun()
        {
            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;
            HardWork(p);
            void WriteProgressToConsole(int percentComplete) => Console.WriteLine(percentComplete);
            void WriteProgressToFile(int percentComplete) =>
                System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());
        }

        private delegate T GenericTransformer<T>(T x);

        public static void DelegateGeneralPlugInRun()
        {
            int[] values = { 1, 2, 3 };
            GenericTransformer<int>? t = null;
            t += Square;
            t += Sqrt;
            t += Cube;
            Transform(values, t);
            Output(values);

            int Square(int x) => x * x;
            int Sqrt(int x) => Convert.ToInt32(Math.Sqrt(x));
            int Cube(int x) => x * x * x;
            static void Transform(int[] values, GenericTransformer<int> t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
            static void Output(int[] values)
            {
                foreach (int i in values)
                    Console.Write(i + " "); // 1 4 9
            }
        }

        public static void PriceChangedRun()
        {
            static void stock_PriceChanged(object? sender, EventArgs e)
            {
                var args = e as PriceChangedEventArgs;
                if ((args is not null) && (args.NewPrice - args.LastPrice) / args.LastPrice > 0.1M)
                    Console.WriteLine("Alert, 10% stock price increase!");
            }
            Stock stock = new("THPW") { Price = 27.10M };
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;
        }

        public static void ClosureRun()
        {
            static Func<int> Natural()
            {
                int seed = 0;
                return int () => seed++;
            }

            Func<int> natural = Natural();
            System.Console.WriteLine(natural());
            System.Console.WriteLine(natural());
        }

        public static void IteratorsRun()
        {
            string name = typeof(Program).Namespace ?? "None";
            #region Collapse tow following lines
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Environment.OSVersion.VersionString);
            #endregion
            Console.WriteLine($"Namespace: {name}");
            foreach (int fib in Fibonachi.EvenNumbersOnly(Fibonachi.Fibs(6)))
                Console.WriteLine(fib);
        }

        public static async void MakeBreakfastRun()
        {
            Coffee cup = AsyncBreakfast.PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = AsyncBreakfast.FryEggsAsync(2);
            var baconTask = AsyncBreakfast.FryBaconAsync(3);
            var toastTask = AsyncBreakfast.MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = AsyncBreakfast.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        public static void AnotherThreadRun()
        {
            Thread tY = new(WriteY);
            tY.Name = "WriteY";
            Thread tSpace = new(WriteSpace);
            tSpace.Name = "WriteSpace";
            System.Console.WriteLine($"tY ThreadState: {tY.ThreadState}");

            tY.Start();
            tY.Join(); // Wait for tY to finish
            tSpace.Start();

            Thread tBlock = new(BlockThreadForTenSec);
            tBlock.Start();

            for (int i = 0; i < 1000; i++) Console.Write("x");
            Thread.Yield(); // Give tSpace a chance to run

            if ((tBlock.ThreadState & ThreadState.WaitSleepJoin) != 0)
            {
                System.Console.WriteLine("Check from main thread: Thread is blocked");
            }

            static void WriteY()
            {
                for (int i = 0; i < 1000; i++) Console.Write("y");
            }
            static void WriteSpace()
            {
                for (int i = 0; i < 1000; i++) Console.Write(" ");
            }

            static void BlockThreadForTenSec()
            {
                Console.WriteLine("Thread is blocked for 10 seconds");
                Thread.Sleep(10000);
                Console.WriteLine("Thread is unblocked");
            }
        }

        public static void ThreadLocalAndSharedStatesRun()
        {
            bool _done = false; // Shared state
            Thread t = new Thread(Go);
            t.Start(); // Call Go() on a new thread
            Go(); // Call Go() on the main thread
            void Go()
            {
                Console.Write(" ");
                // Declare and use a local variable - 'cycles'
                for (int cycles = 0; cycles < 5; cycles++)
                {
                    if (cycles == 3 || _done == true)
                    {
                        _done = true; // Change the shared state
                        Console.WriteLine("Done");
                        break;
                    }


                    Console.Write($"{cycles} ");
                }
            }
        }
        public static void SHA256ServerToServerSignature()
        {
            var message = "{\"body\":{\"kco\":\"10\",\"OrderNo\":\"HS-LB01/00664\"}}";
            var privateKey = "EiOxQ5btZjts2ub47hw9cHaG95ZyYTOYIVy3hpcGqSdRFAc8Sr";
            var hash = Hashing.SHA256AsHex(message + privateKey);
            Console.WriteLine(hash);
        }

        public static void ThreadSafeRun()
        {
            Thread go = new(ThreadSafe.Go);
            go.Start();
            ThreadSafe.Go();
        }

        public static void PassingAndCaptureDataToThread()
        {
            List<string> title = new();
            Action<List<string>, int> action =
            (title, index) =>
            {
                lock (title)
                {
                    title.Add(index.ToString());
                }
            };

            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                Thread thread1 = new(() => action(title, temp));
                thread1.Name = "Thread 1" + temp;
                Thread thread2 = new(() => action(title, temp));
                thread1.Name = "Thread 2" + temp;
                Thread thread3 = new(() => action(title, temp));
                thread1.Name = "Thread 3" + temp;
                thread1.Start();
                thread2.Start();
                thread3.Start();
            }
            // Wait for all threads to finish 
            // It's bad idea however at the stage of knowledge I have right now it's OK
            // Improve this code to have bool shared_done across all threads
            // Its changed to true when delegate process 9 three times
            Thread.Sleep(1000);
            foreach (var item in title)
            {
                Console.WriteLine(item);
            }
        }

        public static void ForegroundAndBackgroundThreads()
        {
            Console.WriteLine("Do you want to run the thread in the background? (yes/no)");
            var input = Console.ReadLine();
            bool isBackground = input switch
            {
                "yes" => true,
                "no" => false,
                _ => false
            };
            Thread worker = new(() =>
            {
                try
                {
                    Console.WriteLine("Thread is running. Waiting for user's input:");
                    Console.ReadLine();
                }
                finally
                {
                    Console.WriteLine("Thread is exiting.");
                }
            });
            worker.IsBackground = isBackground;
            worker.Start();
        }

        public static void SignalingRun()
        {
            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal!");
            }).Start();
            Thread.Sleep(2000);
            signal.Set(); // “Open” the signal
        }

        public static void AwaitTaskRun()
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Foo");
            });
            Console.WriteLine(task.IsCompleted); // False
            task.Wait(); // Blocks until task is complete
        }

        public static void TaskReturningValue()
        {
            Task<int> primeNumberTask = Task.Run(() =>
                Enumerable.Range(2, 3000000).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            Console.WriteLine("Task running...");
            Console.WriteLine("The answer is " + primeNumberTask.Result); // if task is not finished it will block the thread primeNumberTask
        }

        public static void TaskContinuationsUsingAwaiter()
        {
            Task<int> primeNumberTask = Task.Run(() =>
             Enumerable.Range(2, 3000000).Count(n =>
             Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result); // Writes result
            });
        }

        public static void TaskContinuationUsingContinueWith()
        {
            Task<int> primeNumberTask = Task.Run(() =>
             Enumerable.Range(2, 3000000).Count(n =>
             Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            primeNumberTask.ContinueWith(antecedent =>
            {
                int result = antecedent.Result;
                Console.WriteLine(result); // Writes 123
            });
        }

        public static void TaskCompletionSourceRun()
        {
            var tcs = new TaskCompletionSource<int>();
            Task<int> task = tcs.Task; // Our "slave" task.
            new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); }) { IsBackground = true }.Start();
            Console.WriteLine(task.Result); // 42
        }

        public static void SyncPrimesRun()
        {
            var primes = new PracticeLib.Primes();
            int countOfPrimesInTheRange = primes.GetPrimesCount(2, 10000000);
            Console.WriteLine($"The count of prime numbers in a range 2, 10000000 is {countOfPrimesInTheRange}");
        }

        public static async Task DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var primeCount = await PracticeLib.Primes.GetPrimesCountAsync(i * 1000000 + 2, 1000000);
                Console.WriteLine(primeCount +
                " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
            }
            Console.WriteLine("Done!");
        }

    }
}
