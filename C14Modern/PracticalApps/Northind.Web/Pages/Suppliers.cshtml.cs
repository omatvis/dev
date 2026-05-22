using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace Northind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private NorthwindContext _db;
        public IEnumerable<Supplier>? Suppliers { get; set; }

        [BindProperty]
        public Supplier? Supplier { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";
            Suppliers = _db.Suppliers
               .OrderBy(c => c.Country)
               .ThenBy(c => c.CompanyName);
        }
        public SuppliersModel(NorthwindContext db)
        {
            _db = db;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Add(Supplier!);
                _db.SaveChanges();
                return RedirectToPage("/Suppliers");
            }
            return Page();
        }
    }
}
