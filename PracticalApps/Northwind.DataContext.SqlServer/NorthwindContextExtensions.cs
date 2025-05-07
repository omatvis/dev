using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use the UseSqlServer method.
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; // To use IServiceCollection.

namespace Northwind.EntityModels;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddNorthwindContext(
      this IServiceCollection services, // The type to extend.
      string? connectionString = null)
    {
        if (connectionString is null)
        {
            ConfigurationBuilder secretsBuilder = new();
            secretsBuilder.AddUserSecrets<NorthwindContext>();
            IConfiguration configuration = secretsBuilder.Build();

            // Retrieve the secret
            string secretUserId = configuration["DB_USER"] ?? "";
            string secretPwd = configuration["DB_PWD"] ?? "";

            SqlConnectionStringBuilder builder = new();

            builder.DataSource = "127.0.0.1"; // "ServerName\InstanceName" e.g. @".\sqlexpress"
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            // Because we want to fail faster. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            // If using SQL Server authentication.
            builder.UserID = secretUserId;
            builder.Password = secretPwd;

            connectionString = builder.ConnectionString;
        }

        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connectionString);

            options.LogTo(NorthwindContextLogger.WriteLine,
              new[] { Microsoft.EntityFrameworkCore
          .Diagnostics.RelationalEventId.CommandExecuting });
        },
        // Register with a transient lifetime to avoid concurrency 
        // issues with Blazor Server projects.
        contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);

        return services;
    }
}