using System.Data.Common;
using LinqQueries;

partial class Program
{
    private static void Main(string[] args)
    {
        using (Northwind db = new())
        {
            string uniqueCitiesComma = String.Join(
                ",",
                db.Customer.Select(row => row.City).Distinct()
            );

            WriteLine(uniqueCitiesComma);

            Write("Enter the name of a city: ");
            string? input = ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Write("You have not entered the name of the city!");
                return;
            }

            IQueryable<Customer> customers = db.Customer.Where(row => row.City == input);
            foreach (Customer customer in customers)
            {
                WriteLine(customer.CompanyName);
            }
        }
    }
}
