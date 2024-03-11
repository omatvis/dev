namespace EnumeratorExecise;

class Program
{
    static void Main(string[] args)
    {
        IntegralEnumerable i = new();
        foreach (var item in i)
        {
            Console.WriteLine($"Enumerating int from 0 to 100 with step 2. Value: {item}");
        }
    }
}
