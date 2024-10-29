using Microsoft.EntityFrameworkCore;

namespace LinqQueries;

public class Northwind : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            $"Server=127.0.0.1;Database=Northwind;User Id=sa;Password=Testing1122;TrustServerCertificate=True;MultipleActiveResultSets=True";
        optionsBuilder.UseSqlServer(connection);
    }
}
