namespace ParamsModifier;

internal class Program
{
    private static void Main(string[] args)
    {
        int total = Sum([1, 2, 3, 4]);
        Console.WriteLine(total);

        int total2 = Sum(1, 2, 3, 4);
        Console.WriteLine(total2);
    }

    public static int Sum(params int[] ints)
    {
        int sum = 0;
        for (int i = 0; i < ints.Length; i++)
        {
            sum += ints[i];
        }
        return sum;
    }
}
