using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Packt.Shared;

namespace Northwind.Web.Pages;

public class CustomerDetailsModel : PageModel
{
    public IEnumerable<Customer>? Customers { get; set; }
    public Customer? SelectedCustomer { get; set; }
    public IEnumerable<Order>? CustomerOrders { get; set; }
    private NorthwindContext db;

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Customer Details";
        Customers = db.Customers;
        IQueryCollection queries = HttpContext.Request.Query;

        string customerIdValue =
            (queries.ContainsKey("CustomerId") == true) ? queries["CustomerId"].ToString() : "";

        SelectedCustomer = Customers.FirstOrDefault(x => x.CustomerId == customerIdValue);

        CustomerOrders = db.Orders.Where(x => x.CustomerId == customerIdValue);
    }

    public CustomerDetailsModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }
}
