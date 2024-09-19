using PacktLib.Shared;

internal class Program
{
    private static void Main(string[] args)
    {
        Person bob = new();
        bob.Name = "Bob Smith";
        bob.DateOfBirth = new DateOnly(1965, 12, 22);

        WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}");

        Person alice = new() { Name = "Alice Jones", DateOfBirth = new DateOnly(1998, 3, 7) };
        WriteLine($"{alice.Name} was born on {alice.DateOfBirth:dddd, d MMMM yyyy}");

        bob.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        WriteLine(
            $"{bob.Name}'s favourite wonder is {bob.FavouriteAncientWonder}. Its integer is {(int)bob.FavouriteAncientWonder}."
        );

        bob.BucketList =
            WondersOfTheAncientWorld.HangingGardensOfBabylon
            | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
        // bob.BucketList = (WondersOfTheAncientWorld)18;
        WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

        bob.Children.Add(new Person { Name = "Alfred" }); // C# 3.0 and later
        bob.Children.Add(new() { Name = "Zoe" }); // C# 9.0 and later
        WriteLine($"{bob.Name} has {bob.Children.Count} children:");
        for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
        {
            WriteLine($"> {bob.Children[childIndex].Name}");
        }

        BankAccount.InterestRate = 0.012M; // store a shared value
        BankAccount jonesAccount = new() { AccountName = "Mrs. Jones", Balance = 2400 };
        WriteLine(
            format: "{0} earned {1:C} interest.",
            arg0: jonesAccount.AccountName,
            arg1: jonesAccount.Balance * BankAccount.InterestRate
        );
        BankAccount gerrierAccount = new() { AccountName = "Ms. Gerrier", Balance = 98 };
        WriteLine(
            format: "{0} earned {1:C} interest.",
            arg0: gerrierAccount.AccountName,
            arg1: gerrierAccount.Balance * BankAccount.InterestRate
        );

        WriteLine($"{bob.Name} is a {Person.Species}");
        WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

        Person blankPerson = new();
        WriteLine(
            format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,
            arg1: blankPerson.HomePlanet,
            arg2: blankPerson.Instantiated
        );

        Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
        WriteLine(
            format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,
            arg1: blankPerson.HomePlanet,
            arg2: blankPerson.Instantiated
        );

        bob.WriteToConsole();
        WriteLine(bob.GetOrigin());

        (string, int) fruit = bob.GetFruit();
        WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

        var fruitNames = bob.GetNamedFruit();
        WriteLine($"{fruitNames.Name}, {fruitNames.Number} there are.");

        var thing1 = ("Neville", 4);
        WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
        var thing2 = (bob.Name, bob.Children.Count);
        WriteLine($"{thing2.Name} has {thing2.Count} children.");

        (String fruitName, int fruitNumber) = bob.GetNamedFruit();
        WriteLine($"{fruitName}, {fruitNumber} there are.");

        // Deconstructing a Person
        var (name1, dob1) = bob;
        // implicitly calls the Deconstruct method
        WriteLine($"Deconstructed: {name1}, {dob1}");
        var (name2, dob2, fav2) = bob;
        WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

        WriteLine(bob.SayHello());
        WriteLine(bob.SayHello("Emily"));

        WriteLine(bob.OptionalParameters(command: "Jump!", number: 98.5));

        int a = 10;
        int b = 20;
        int c = 30;
        WriteLine($"Before: a = {a}, b = {b}, c = {c}");
        bob.PassingParameters(a, ref b, out c);
        WriteLine($"After: a = {a}, b = {b}, c = {c}");
    }
}
