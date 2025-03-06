using System;

namespace PracticeLib;

public class PriceChangedEventArgs(decimal lastPrice, decimal newPrice) : System.EventArgs
{
    public readonly decimal LastPrice = lastPrice;
    public readonly decimal NewPrice = newPrice;
}

public class Stock
{
    string symbol;
    decimal price = 0.0m;

    public Stock(string symbol) => this.symbol = symbol;

    public event EventHandler<EventArgs>? PriceChanged = null;

    protected virtual void OnPriceChanged(EventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (price == value)
                return;
            decimal oldPrice = price;
            price = value;
            OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
        }
    }
}
