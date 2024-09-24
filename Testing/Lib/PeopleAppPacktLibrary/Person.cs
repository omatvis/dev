namespace Packt.Shared;

public class Person : object
{
    // properties
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int AngerLevel1
    {
        get => AngerLevel;
    }

    // delegate field
    public event EventHandler? Shout;

    // data field
    private int AngerLevel;

    // methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel >= 3)
        {
            // if something is listening...
            Shout?.Invoke(this, EventArgs.Empty);
        }
    }
}
