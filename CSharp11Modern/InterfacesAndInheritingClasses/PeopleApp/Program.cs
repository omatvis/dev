namespace PeopleApp;

using Packt.Shared;

partial class Program
{
    static void Main(string[] args)
    {
        Person harry = new() { Name = "Harry", DateOfBirth = new(year: 2001, month: 3, day: 25) };
        harry.WriteToConsole();

        // Avoid types imported into the System.Collections namespace. Use types imported in System.Collections.Generics
        System.Collections.Hashtable lookupObject = [];
        lookupObject.Add(key: 1, value: "Alpha");
        lookupObject.Add(key: 2, value: "Beta");
        lookupObject.Add(key: 3, value: "Gamma");
        lookupObject.Add(key: harry, value: "Delta");

        int key = 2;
        Console.WriteLine($"Key {key} has value: {lookupObject[key]}");
        Console.WriteLine($"Key {harry} has value: {lookupObject[harry]}");

        // A Key should be unique
        Dictionary<int, string> lookupIntString = [];
        lookupIntString.Add(key: 1, value: "Alpha");
        lookupIntString.Add(key: 2, value: "Beta");
        lookupIntString.Add(key: 3, value: "Gamma");
        lookupIntString.Add(key: 4, value: "Delta");

        key = 3;
        Console.WriteLine($"Key {key} has value: {lookupIntString[key]}");

        harry.Shout += Harry_Shout;
        harry.Shout += Harry_Shout2;

        harry.Poke();
        harry.Poke();
        harry.Poke();
        harry.Poke();

        Person?[] people = {
            null,
            new() {Name = "Simon"},
            new() {Name = "Jenny"},
            new() {Name = "Adam"},
            new() {Name = null},
            new() {Name = "Richard"},
        };
        OutputPeoplenames(people, "Initial list of people:");
        Array.Sort(people);
        OutputPeoplenames(people, "After sorting using Person's IComparable implementation:");
    }
}
