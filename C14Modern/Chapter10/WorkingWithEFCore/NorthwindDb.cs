using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Northwind.EntityModels
{
    public class NorthwindDb : DbContext
    {
        // These two properties map to tables in the database.
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read SA password from user secrets key "sa_sql_pwd"
            // Requires package: Microsoft.Extensions.Configuration.UserSecrets
            var config = new ConfigurationBuilder()
                .AddUserSecrets<NorthwindDb>()
                .AddEnvironmentVariables()
                .Build();

            var saPassword = config["sa_sql_pwd"];
            if (string.IsNullOrEmpty(saPassword))
            {
                throw new InvalidOperationException("Secret 'sa_sql_pwd' not found. Set it with `dotnet user-secrets set \"sa_sql_pwd\" \"<password>\"`.");
            }

            // Build a clean connection string (no leading spaces)
            var csBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "172.26.219.91",
                InitialCatalog = "Northwind",
                UserID = "sa",
                Password = saPassword,
                Encrypt = true,                   // SSMS: Encrypt = Mandatory
                TrustServerCertificate = true,    // SSMS: Trust Server Certificate = checked
                MultipleActiveResultSets = true,
                ConnectTimeout = 30
            };

            optionsBuilder.UseSqlServer(csBuilder.ConnectionString, sqlOptions =>
            {
                sqlOptions.CommandTimeout(180);
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(15),
                    errorNumbersToAdd: null);
                sqlOptions.MigrationsAssembly(typeof(NorthwindDb).Assembly.FullName);
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration can go here if needed.
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}