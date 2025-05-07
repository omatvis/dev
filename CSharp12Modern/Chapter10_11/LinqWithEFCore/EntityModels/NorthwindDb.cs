using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets; // Add this namespace

namespace LinqWithEFCore.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("EntityModels/appconfig.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<NorthwindDb>() // Add user secrets
            .Build();

        string? userId = configuration["ConnectionStrings:NorthwindDb:UserId"];
        string? password = configuration["ConnectionStrings:NorthwindDb:Password"];
        string? connectionString = configuration.GetConnectionString("NorthwindDb")?
            .Replace("{DB_USER}", userId)
            .Replace("{DB_PASSWORD}", password);

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
