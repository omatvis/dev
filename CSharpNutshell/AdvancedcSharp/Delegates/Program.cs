using System.Runtime.CompilerServices;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Delegates delegates = new Delegates();
        Handlers handlers = new Handlers();
        delegates.Transform = new(handlers.Square);
        int result = delegates.Transform.Invoke(5);
        System.Console.WriteLine($"5 x 5 = {result}");

        delegates.Transform = handlers.Square;
        result = delegates.Transform(55);
        System.Console.WriteLine($"5 x 5 = {result}");

        int[] ints = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Transform<int>(ints, Cube);
        foreach (int el in ints)
        {
            System.Console.WriteLine($"cube = {el}");
        }

        MyReporter r = new() { Prefix = "%Complete: " };
        ProgressReporter p = r.ReportProgress;
        p(99); // %Complete: 99
        Console.WriteLine(p.Target == r); // True
        Console.WriteLine(p.Method); // Void ReportProgress(Int32)
        r.Prefix = "";
        p(99); // 99
    }

    private static int Cube(int x) => x * x * x;

    private delegate void ProgressReporter(int percentComplete);

    public static void Transform<T>(T[] values, Func<T, T> transformer)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = transformer(values[i]);
    }
}
