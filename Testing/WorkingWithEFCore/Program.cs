
using Packt.Shared;
internal class Program
{
    private static void Main(string[] args)
    {
        Northwind db = new();
        WriteLine($"Provider: {db.Database.ProviderName}");
    }
}