using Animals;

internal class Program
{
    private static void Main(string[] args)
    {
        Panda panda1 = new("Pan Dee");
        Panda panda2 = new("Pan Dah");

        System.Console.WriteLine(panda1.Name);
        System.Console.WriteLine(panda2.Name);

        System.Console.WriteLine(Panda.Population);
    }
}
