using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.

namespace WorkingWithEFCore
{
    partial class Program
    {
        private static void QueryingCategories()
        {
            using NorthwindDb db = new();

            SectionTitle("Categories and how many products they have");

            IQueryable<Category> categories = db.Categories!.Include(c => c.Products);

            if (categories is null)
            {
                Fail("No categories found.");
                return;
            }

            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }
    }
}
