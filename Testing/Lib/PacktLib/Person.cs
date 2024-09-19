using System;

namespace PacktLib.Shared;

public class Person : Object
{
    private string? name;
    public DateOnly DateOfBirth;
    public WondersOfTheAncientWorld FavouriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = [];
    public const string Species = "Homi Sapiends";

    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    public string? Name
    {
        get { return name; }
        set => name = value;
    }

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    // methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}.";
    }

    public (string, int) GetFruit()
    {
        return ("Apple", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apple", Number: 5);
    }

    public void Deconstruct(out string? name, out DateOnly dob)
    {
        name = Name;
        dob = DateOfBirth;
    }

    public void Deconstruct(out string? name, out DateOnly dob, out WondersOfTheAncientWorld fav)
    {
        Deconstruct(out name, out dob);
        fav = FavouriteAncientWonder;
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(
        string command = "Run!",
        double number = 0.0,
        bool active = true
    )
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active
        );
    }

    public void PassingParameters(int x, ref int y, out int z)
    {
        // out parameters cannot have a default
        // AND must be initialized inside the method
        z = 99;
        // increment each parameter
        x++;
        y++;
        z++;
    }
}
