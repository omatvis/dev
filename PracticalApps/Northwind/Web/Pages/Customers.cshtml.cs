using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Packt.Shared;

namespace Northwind.Web.Pages;

public class CustomersModel : PageModel
{
    public IEnumerable<Customer>? Customers { get; set; }

    private NorthwindContext db;

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Customers";
        Customers = db.Customers;
    }

    public CustomersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    public IEnumerable<IGrouping<string?, Customer>> CustomersGroupByCountry
    {
        get { return db.Customers.GroupBy(customer => customer.Country); }
    }
}
