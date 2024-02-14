namespace ReferenceAndValueType;

class Program
{
    static void Main(string[] args)
    {
        int a = 3;
        int b = 4;
        int c = 0;

        Multiply(a, b, c);
        Console.WriteLine($"global statement: {a} x {b} = {c}");

        static void Multiply(int a, int b, int c)
        {
            c = a * b;
            Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
        }

        int[] array = [1, 2, 3, 4, 5];

        PrintArray(array);
        Clear(array);
        PrintArray(array);

        void PrintArray(int[] array)
        {
            foreach (int a in array)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
        }

        void Clear(int[] array)
        {
            Array.Clear(array);
            Array.Fill<int>(array, 0);
        }

        string status = "Healthy";

        Console.WriteLine($"Start: {status}");
        SetHealth(false);
        Console.WriteLine($"End: {status}");

        void SetHealth(bool isHealthy)
        {
            status = (isHealthy ? "Healthy" : "Unhealthy");
            Console.WriteLine($"Middle: {status}");
        }
    }
}
