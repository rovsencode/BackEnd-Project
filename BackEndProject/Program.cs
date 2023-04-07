using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Services;
using BackEndProject.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BackEndProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _config = builder.Configuration;
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            builder.Services.BackEndServiceRegistration();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(15);
            });
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //builder.Services.AddScoped<IEmailService, EmailService>();
            //builder.Services.AddScoped<IFileService, FileService>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           app.Run();
        }
    }
}