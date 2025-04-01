using EFCoreEagerLazyImplicitLoading.DB.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreEagerLazyImplicitLoading;

class Program
{
    static void Main(string[] args)
    {
        // Eager loading
        using (var db = new Northwind())
        {
            Console.WriteLine("Eager Loading");
            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

            if ((categories is null) || (!categories.Any()))
            {
                Console.WriteLine("No categories found!");
                return;
            }
            /* EFCore generates SELECT Parent Left Join Child */
            foreach (Category c in categories)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }

        // Lazy loading
        using (var db = new Northwind(UseLazyLoading: true))
        {
            Console.WriteLine("Lazy Loading");
            IQueryable<Category>? categories = db.Categories;
            if ((categories is null) || (!categories.Any()))
            {
                Console.WriteLine("No categories found!");
                return;
            }
            foreach (Category c in categories)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }

        // Explicit Loading
        using (var db = new Northwind())
        {
            Console.WriteLine("Explicit Loading");
            IQueryable<Category>? categories = db.Categories;
            foreach (Category c in categories)
            {
                CollectionEntry<Category, Product> products = db.Entry(c)
                    .Collection(c2 => c2.Products);
                if (!products.IsLoaded)
                    products.Load();
            }
        }
    }
}
