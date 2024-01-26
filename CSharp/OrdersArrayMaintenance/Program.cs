namespace OrdersArrayMaintenance;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
        string[] orders = orderStream.Split(",");
        Array.Sort(orders);
        foreach (string order in orders)
        {
            Console.Write(order);
            if (order.Length != 4)
            {
                Console.WriteLine("     - Error");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
