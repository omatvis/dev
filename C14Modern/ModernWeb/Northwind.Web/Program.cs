using Microsoft.AspNetCore.Hosting.StaticWebAssets;

namespace Northwind.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.MapStaticAssets();

            app.MapGet("/env", () => $"Environment is {app.Environment.EnvironmentName}");

            app.MapGet("/data", () => Results.Json(new
            {
                firstName = "John",
                lastName = "Doe",
                age = 30
            }));

            app.MapGet("/welcome", () => Results.Content(
                content: $"""
                <!doctype html>
                <html lang="en">
                <head>
                  <meta charset="utf-8" />
                  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
                  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
                  <link href="site.css" rel="stylesheet" />
                  <title>About Northwind Web</title>
                </head>
                <body>
                  <div class="container">
                    <div class="jumbotron">
                      <h1 class="display-3">About Northwind Web</h1>
                      <p class="lead">We supply products to our customers.</p>
                      <img src="categories.jpeg" style="height:200px;width:300px;" />
                    </div>
                  </div>
                </body>
                </html>
                """,
                contentType: "text/html"));

            app.Run();

            Console.WriteLine("The execution is stepped");
        }
    }
}
