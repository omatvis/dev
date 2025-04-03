using System;
using Packt.Shared;
internal partial class Program
{
    private static void Main(string[] args)
    {
        ConfigureConsole();
        Person bob = new()
        {
            Name = "Bob Smith",
            Born = new DateTimeOffset(
                year: 1965, month: 12, day: 22,
                hour: 16, minute: 28, second: 0,
                offset: TimeSpan.FromHours(-5)) // US Eastern Standard Time.
        };
        bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

        WriteLine(format: "{0} was born on {1:D}.", // Long date.
         arg0: bob.Name, arg1: bob.Born);
        WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
                  arg0: bob.Name,
                  arg1: bob.FavoriteAncientWonder,
                  arg2: (int)bob.FavoriteAncientWonder);

        bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
        // bob.BucketList = (WondersOfTheAncientWorld)18;
        WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

        Person alice = new()
        {
            Name = "Alice Jones",
            Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
        };
        WriteLine(format: "{0} was born on {1:d}.", arg0: alice.Name, arg1: alice.Born);

        // Works with all versions of C#.
        Person alfred = new();
        alfred.Name = "Alfred";
        bob.AddChild(alfred);
        // Works with C# 3 and later.
        bob.AddChild(new Person { Name = "Bella" });
        // Works with C# 9 and later.
        bob.AddChild(new() { Name = "Zoe" });
        WriteLine($"{bob.Name} has {bob.ChildrenCount} children:");
        for (int childIndex = 0; childIndex < bob.ChildrenCount; childIndex++)
        {
            WriteLine($"> {bob[childIndex].Name}");
        }

        BankAccount.InterestRate = 0.012M; // Store a shared value in static field.
        BankAccount jonesAccount = new();
        jonesAccount.AccountName = "Mrs. Jones";
        jonesAccount.Balance = 2400;
        WriteLine(format: "{0} earned {1:C} interest.",
         arg0: jonesAccount.AccountName,
         arg1: jonesAccount.Balance * BankAccount.InterestRate);
        BankAccount gerrierAccount = new();
        gerrierAccount.AccountName = "Ms. Gerrier";
        gerrierAccount.Balance = 98;
        WriteLine(format: "{0} earned {1:C} interest.",
         arg0: gerrierAccount.AccountName,
         arg1: gerrierAccount.Balance * BankAccount.InterestRate);

    }
}