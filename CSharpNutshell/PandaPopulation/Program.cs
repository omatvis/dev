using PandaPopulation;

internal class Program
{
    private static void Main(string[] args)
    {
        Panda p1 = new("Pan Dee");
        Panda p2 = new("Pan Dah");
        Console.WriteLine(p1.Name); // Pan Dee
        Console.WriteLine(p2.Name); // Pan Dah
        Console.WriteLine(Panda.Population); // 2
    }
}