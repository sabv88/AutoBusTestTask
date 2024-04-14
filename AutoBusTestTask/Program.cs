using AutoBusTestTask.Data;
using AutoBusTestTask.Interfaces;
using AutoBusTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AutoBusTestTaskDbContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 0)));
            });
            builder.Services.AddScoped<IAutoBusTestTaskDbContext>(provider =>
            provider.GetService<AutoBusTestTaskDbContext>());

            builder.Services.AddTransient<IUrlRepository, UrlRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "RedirectToOriginalUrl",
                pattern: "{*shortUrl}",
                defaults: new { controller = "Home", action = "RedirectToOriginalUrl" });
            app.Run();
        }
    }
}