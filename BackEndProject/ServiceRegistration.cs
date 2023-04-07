using BackEndProject.Helpers;
using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject
{
    public static class ServiceRegistration
    {
        public static void BackEndServiceRegistration(this IServiceCollection services)
        {
          
            services.AddHttpContextAccessor();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit=true;
                options.Password.RequireLowercase=true;
                options.Password.RequireUppercase=true;

                options.User.RequireUniqueEmail=true;

                options.Lockout.AllowedForNewUsers=true;
                options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 3;
            });

        } 
    }
}

