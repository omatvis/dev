using Microsoft.EntityFrameworkCore; // To use DbContext and so on
using Microsoft.EntityFrameworkCore.Diagnostics;// To use RelationalEventId.

namespace Northwind.EntityModels;

/// <summary>
/// This manages interactions with the Northwind database.
/// </summary>
public class NorthwindDb : DbContext
{
    // These two properties map to tables in the database.
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"
            Server=127.0.0.1;Database=Northwind;
            User Id=sa;Password=Testing1122;TrustServerCertificate=True;MultipleActiveResultSets=True"
        ).UseLazyLoadingProxies();
        optionsBuilder.LogTo(WriteLine, new[] { RelationalEventId.CommandExecuting }) // This is the Console method.
#if DEBUG
            .EnableSensitiveDataLogging() // Include SQL parameters.
            .EnableDetailedErrors()
#endif
        ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes
        // to limit the length of a category name to 15.
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired() // NOT NULL
        .HasMaxLength(15);

        // A global filter to remove discontinued products.
        modelBuilder.Entity<Product>()
         .HasQueryFilter(p => !p.Discontinued);
    }
}

