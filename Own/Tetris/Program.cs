namespace Tetris;

class Program
{
    static void Main(string[] args)
    {
        WriteLine("Press any key combination");
        ConsoleKeyInfo key = ReadKey();
        WriteLine();
        WriteLine($"Key: {key.Key}, Char: {key.KeyChar}, Modifiers: {key.Modifiers}");

    }
}
