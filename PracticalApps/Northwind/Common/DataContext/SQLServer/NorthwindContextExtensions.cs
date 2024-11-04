using Microsoft.EntityFrameworkCore; // UseSqlServer
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services,
        string connectionString =
            "Server=127.0.0.1;Database=Northwind;User Id=sa;Password=Testing1122;TrustServerCertificate=True;"
    )
    {
        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.LogTo(
                WriteLine, // Console
                [
                    Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting
                ]
            );
        });
        return services;
    }
}
