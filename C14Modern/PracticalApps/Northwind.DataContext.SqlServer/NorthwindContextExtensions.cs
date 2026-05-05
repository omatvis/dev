using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.EntityModels
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<NorthwindContext>(options =>
                { 
                    options.UseSqlServer(connectionString);
                    options.LogTo(NorthwindContextLogger.WriteLine, [Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting]);
                },ServiceLifetime.Transient, ServiceLifetime.Transient);
        }
    }
}
