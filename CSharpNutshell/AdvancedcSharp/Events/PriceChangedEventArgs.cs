public class PriceChangedEventArgs(decimal lastPrice, decimal newPrice) : System.EventArgs
{
    public readonly decimal LastPrice = lastPrice;
    public readonly decimal NewPrice = newPrice;
}
