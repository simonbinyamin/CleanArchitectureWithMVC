using mediatR.Business.Common.Interfaces;
using mediatR.DataAccess.Files;
using mediatR.DataAccess.Identity;
using mediatR.DataAccess.Persistence;
using mediatR.DataAccess.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace mediatR.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
     
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
      

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;

            });

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            return services;
        }
    }
}