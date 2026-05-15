namespace Northind.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            var app = builder.Build();

            #region Configure the HTTP pipeline and routes
            if (!app.Environment.IsDevelopment()) app.UseHsts();            
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapRazorPages();
            app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");
            #endregion

            app.Run();

            Console.WriteLine("This executes after the app has started.");
        }
    }
}
