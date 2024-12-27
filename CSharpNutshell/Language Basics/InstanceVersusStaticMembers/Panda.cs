namespace Animals;

public class Panda
{
    public string Name;
    public static int Population = 0;

    public Panda(string name)
    {
        Name = name;
        ++Population;
    }
}
