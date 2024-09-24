using Packt.Shared;

namespace PeopleApp;

class delegMethodClass : Object
{
    internal int someMethod(int flag)
    {
        return flag;
    }
}

partial class Program
{
    public delegate int pointSomeMethod(int flag);

    static void Main(string[] args)
    {
        Person harry = new() { Name = "Harry", DateOfBirth = new(year: 2001, month: 3, day: 25) };

        // non-generic lookup collection
        System.Collections.Hashtable lookupObject = new();
        lookupObject.Add(key: 1, value: "Alpha");
        lookupObject.Add(key: 2, value: "Beta");
        lookupObject.Add(key: 3, value: "Gamma");
        lookupObject.Add(key: harry, value: "Delta");

        int key = 2; // look up the value that has 2 as its key
        WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupObject[key]);

        // look up the value that has harry as its key
        WriteLine(format: "Key {0} has value: {1}", arg0: harry, arg1: lookupObject[harry]);

        // generic lookup collection
        Dictionary<int, string> lookupIntString = new();
        lookupIntString.Add(key: 1, value: "Alpha");
        lookupIntString.Add(key: 2, value: "Beta");
        lookupIntString.Add(key: 3, value: "Gamma");
        lookupIntString.Add(key: 4, value: "Delta");

        key = 3;
        WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupIntString[key]);

        delegMethodClass ex = new();
        pointSomeMethod caller = new(ex.someMethod);
        WriteLine($"Call a delegated method {caller(2)}");

        // assign a method to the Shout delegate
        harry.Shout += Harry_Shout; // call the Poke method that raises the Shout event
        harry.Shout += Harry_Shout2;
        harry.Poke();
        harry.Poke();
        harry.Poke();
        harry.Poke();

        Person?[] people =
        {
            null,
            new() { Name = "Simon" },
            new() { Name = "Jenny" },
            new() { Name = "Adam" },
            new() { Name = null },
            new() { Name = "Richard" }
        };
        OutputPeopleNames(people, "Initial list of people:");
        Array.Sort(people);
        OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");

        Array.Sort(people, new PersonComparer());
        OutputPeopleNames(people, "After sorting using PersonComparer's IComparer implementation:");
    }
}
