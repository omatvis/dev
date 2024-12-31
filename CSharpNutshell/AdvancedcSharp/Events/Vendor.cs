public class Vendor
{
    public required string name;

    public void ItemPriceHasBeenChanged(object? sender, PriceChangedEventArgs e)
    {
        System.Console.WriteLine(
            $"Vendor: {name} - item old price {e.LastPrice} changed to item new price {e.NewPrice}"
        );
    }
}
