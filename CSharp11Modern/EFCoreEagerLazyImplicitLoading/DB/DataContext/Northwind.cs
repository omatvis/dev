using Microsoft.EntityFrameworkCore;

namespace EFCoreEagerLazyImplicitLoading.DB.DataContext;

public class Northwind : DbContext
{
    private readonly bool useLazyLoading;
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public Northwind(bool UseLazyLoading): base() {
        useLazyLoading = UseLazyLoading;
    }

    public Northwind(): base() {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
            "Server=127.0.0.1;Database=Northwind;User Id=sa;Password=Testing1122;TrustServerCertificate=True;MultipleActiveResultSets=True";
        optionsBuilder
            .UseSqlServer(connectionString)
            .LogTo(
                Console.WriteLine,                
                [DbLoggerCategory.Database.Command.Name],
                Microsoft.Extensions.Logging.LogLevel.Information
            );
        if (useLazyLoading) {
            optionsBuilder.UseLazyLoadingProxies();
        }    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.UnitPrice).HasDefaultValue(0m);
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

            entity
                .HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasConstraintName("FK_Products_Categories");
        });
    }
}
