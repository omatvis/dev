internal class Program
{
    private static void Main(string[] args)
    {
        Vendor v1 = new() { name = "Vendor 1" };
        Vendor v2 = new() { name = "Vendor 2" };

        Stock stock = new("A");
        stock.PriceChanged += v1.ItemPriceHasBeenChanged;
        stock.PriceChanged += v2.ItemPriceHasBeenChanged;

        stock.Price = 22;
        stock.Price = 10;
    }
}
