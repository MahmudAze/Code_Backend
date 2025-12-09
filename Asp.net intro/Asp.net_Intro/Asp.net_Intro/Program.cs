namespace Asp.net_Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "about",
                pattern: "about",
                defaults: new { controller = "About", action = "About" }
            );

            app.MapControllerRoute(
                name: "store",
                pattern: "store",
                defaults: new { controller = "Store", action = "Store" }
            );

            app.MapControllerRoute(
                name: "order",
                pattern: "order",
                defaults: new { controller = "Order", action = "Order" }
            );

            app.MapControllerRoute(
                name: "support",
                pattern: "support",
                defaults: new { controller = "Support", action = "Support" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
