namespace Enforcement_proceedings_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseRouting();

            app.MapControllerRoute(
                    name: "default route",
                    pattern: "{controller=HomePage}/{action=WebSite}"
                );

            app.Run();
        }
    }
}
