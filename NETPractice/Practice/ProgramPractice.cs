using System;
using System.Text;
using PracticeLib;
using PracticeLib.VarianceType;
using PracticeLib.Generics;
using System.Security.Cryptography.X509Certificates;

namespace Practice
{
    partial class Program
    {
        public static void BinaryOperatorComplementRun()
        {
            int a = 0b1;
            string resultComplement = BitwiseOperator.Complement(a);
            Console.WriteLine("Bitwise Complement Operator: ~");
            Console.WriteLine($"~{Convert.ToString(a, 2).PadLeft(32, '0'), 32}");
            Console.WriteLine($"{new string('-', 32), 33}");
            Console.WriteLine($"{resultComplement, 33}");
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
            Stack<Bear> bearStack = new();
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
    }
}
