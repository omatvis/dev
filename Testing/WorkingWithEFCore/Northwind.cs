using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder

namespace Packt.Shared;

// this manages the connection to the database
public class Northwind : DbContext
{
    // these properties map to tables in the database
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            $"Server=192.168.99.107;Database=Northwind;User Id=sa;Password=Testing1122;TrustServerCertificate=True;";
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = previousColor;
        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // example of using Fluent API instead of attributes
        // to limit the length of a category name to 15
        modelBuilder
            .Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // added to "fix" the lack of decimal support in SQLite
            modelBuilder
                .Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }
    }
}
