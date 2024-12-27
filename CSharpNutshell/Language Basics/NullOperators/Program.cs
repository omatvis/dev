using System.Data.SqlTypes;

internal class Program
{
    private static void Main(string[] args)
    {
        string? s1 = null;
        string s2 = s1 ?? "nothing";
        string? s3 = null;
        s3 ??= "nothing 2";

        System.Text.StringBuilder? sb = null;
        string? s = sb?.ToString().ToUpper();
        Console.WriteLine($"{s1} {s2} {s3} {s}");
    }
}
