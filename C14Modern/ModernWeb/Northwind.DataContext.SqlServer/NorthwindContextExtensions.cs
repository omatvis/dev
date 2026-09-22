using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataContext.SqlServer;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Northwind.EntityModels
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(
            this IServiceCollection services)  // The type to extend.
        {
            services.AddDbContext<NorthwindContext>(options =>
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // point appsettings.json folder
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly());

                IConfiguration configuration = configBuilder.Build();

                string? connectionString = configuration.GetConnectionString("DefaultConnection");

                string? dbPwd = configuration["DB_PASSWORD"];

                options.UseSqlServer(connectionString?.Replace("{DB_PASSWORD}", dbPwd));
                options.LogTo(NorthwindContextLogger.WriteLog,
                    [Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting]);
            },

            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);
            return services;


        }
    }
}
