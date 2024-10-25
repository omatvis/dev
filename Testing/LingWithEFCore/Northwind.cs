using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

public class Northwind : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            $"Server=127.0.0.1;Database=Northwind;User Id=sa;Password=Testing1122;TrustServerCertificate=True;MultipleActiveResultSets=True";
        optionsBuilder.UseSqlServer(connection);     
    }
}
