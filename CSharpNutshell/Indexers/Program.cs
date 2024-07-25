using Indexers;

internal class Program
{
    private static void Main(string[] args)
    {
        Sentence s = new Sentence();        
        Console.WriteLine(s[3]);
        s[3] = "kangaru";
        Console.WriteLine(s[3]);
    }
}