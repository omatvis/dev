internal class Program
{
    private static void Main(string[] args)
    {
        Stock msft = new Stock { Name = "MSFT", SharesOwned = 1000 };
        Console.WriteLine(msft.Name); // MSFT
        Console.WriteLine(msft.SharesOwned); // 1000
        House mansion = new House { Name = "Mansion", Mortgage = 250000 };
        Console.WriteLine(mansion.Name); // Mansion
        Console.WriteLine(mansion.Mortgage); // 250000
        Display(mansion);
        Display(msft);

        Asset a = mansion;
        Console.WriteLine(mansion.Liability); // 250000
        Console.WriteLine(a.Liability); // 250000

        Overrider over = new Overrider();
        BaseClass b1 = over;

        over.Foo(); // Overrider.Foo
        b1.Foo(); // Overrider.Foo
        Hider h = new Hider();
        BaseClass b2 = h;
        h.Foo(); // Hider.Foo
        b2.Foo(); // BaseClass.Foo
    }

    public static void Display(Asset asset)
    {
        System.Console.WriteLine(asset.Name);
    }
}
