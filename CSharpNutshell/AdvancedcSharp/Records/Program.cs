internal class Program
{
    private static void Main(string[] args)
    {
        Point p1 = new(3, 3);
        Point p2 = p1 with { Y = 4 };
        Console.WriteLine(p2); // Point { X = 3, Y = 4 }
    }
}
