using System.Text;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var rect = new Rectangle(3, 4);
        (float width, float height) = rect; // Deconstruction
        Console.WriteLine(width + " " + height); // 3 4

        var square = new Square(5) { IsBlack = false };
        Console.WriteLine(square.Area());
        Console.WriteLine(square.IsBlack);

        var s = new ArtificialStringOfChars('a', 'b', 'c');
        foreach (char c in s)
        {
            Console.WriteLine(c);
        }

        System.Console.WriteLine(nameof(StringBuilder) + "." + nameof(StringBuilder.Length));
    }
}
