namespace Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point(10, 20);
            var point2 = new Point(1, 2);
        }
    }

    public struct Point { 
        public readonly int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
