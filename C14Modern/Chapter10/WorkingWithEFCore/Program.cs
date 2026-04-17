namespace WorkingWithEFCore
{

    using Northwind.EntityModels; // To use Northwind.
    partial class Program
    {
        static void Main(string[] args)
        {

            using NorthwindDb db = new();
            if (db.Database.CanConnect())
            {
                Console.WriteLine("Connection successful.");
            }
            else
            {
                Console.WriteLine("Connection failed.");
                return;
            }
            WriteLine($"Provider: {db.Database.ProviderName}");

            ConfigureConsole();
            QueryingCategories();
        }
    }  
}
