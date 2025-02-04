using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Mvc.Data;
using Packt.Shared; // AddNorthwindContext extension method

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found."
            );
        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString)
        );
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services
            .AddDefaultIdentity<IdentityUser>(
                options => options.SignIn.RequireConfirmedAccount = true
            )
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
        // if you are using SQL Server
        string? sqlServerConnection = builder.Configuration.GetConnectionString(
            "NorthwindConnection"
        );
        if (sqlServerConnection is null)
        {
            Console.WriteLine("SQL Server database connection string is missing!");
        }
        else
        {
            builder.Services.AddNorthwindContext(sqlServerConnection);
        }
        builder.Services.AddOutputCache(options =>
        {
            options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(20);
            options.AddPolicy("views", p => p.SetVaryByQuery(""));
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseOutputCache();
        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}")
            .CacheOutput("views");
        ;
        app.MapRazorPages();
        app.MapGet("/notcached", () => DateTime.Now.ToString());
        app.MapGet("/cached", () => DateTime.Now.ToString()).CacheOutput();
        app.Run();
    }
}
