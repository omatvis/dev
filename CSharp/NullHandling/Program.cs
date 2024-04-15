namespace NullHandling;

class Program
{
    static void Main(string[] args)
    {
        int thisCannotBeNull = 4;
        //thisCannotBeNull = null;
        Console.WriteLine(thisCannotBeNull);
        int? thisCouldBeBull = null;
        Console.WriteLine(thisCouldBeBull);
        Console.WriteLine(thisCouldBeBull.GetValueOrDefault());
        thisCouldBeBull = 7;
        Console.WriteLine(thisCouldBeBull);
        Console.WriteLine(thisCouldBeBull.GetValueOrDefault());

        Nullable<int> thisCouldAlsoBeNull = null;
        thisCannotBeNull = 11;
        Console.WriteLine(thisCouldAlsoBeNull);

        Address address = new()
        {
            Building = null,
            Street = null!,
            City = "Lviv",
            Region = "UK"
        };
        Console.WriteLine(address.Building?.Length);
        Console.WriteLine(address.Street?.Length);

    }
}
