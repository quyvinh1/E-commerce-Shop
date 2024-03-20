using Microsoft.EntityFrameworkCore;
using WebAssignment.Models;
using WebAssignment.Repository;

namespace WebAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			var connectionString = builder.Configuration.GetConnectionString("DBContext");
			builder.Services.AddDbContext<PRN211_ProjectContext>(x => x.UseSqlServer("Server=(local);uid=sa;pwd=123;database=PRN211_Project;"));
			builder.Services.AddScoped<IProductCategory, ProductCategoryRepository>();
            builder.Services.AddSession();
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
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}