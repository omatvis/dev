internal class Program
{
    private static void Main(string[] args)
    {
        Point p1 = new Point(3, 3);
        Point p2 = p1 with { Y = 4 };
        Console.WriteLine(p2); // Point { X = 3, Y = 4 }

        Point p3 = new Point(2, 3);
        Console.WriteLine(p3.DistanceFromOrigin); // 3.605551275463989
        Point p4 = p3 with { Y = 4 };
        Console.WriteLine(p4.DistanceFromOrigin); // 4.47213595499958
        Console.ReadKey();
    }
}
