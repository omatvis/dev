using Microsoft.EntityFrameworkCore; // UseSqlServer
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// < param name="services"></param>
    /// <param name="connectionString">Set to override the default . </param>
    /// <returns>An IServiceCollection that can be used to add more services</returns>

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
                Console.WriteLine, // Console
                [
                    Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting
                ]
            );
        });
        return services;
    }
}
