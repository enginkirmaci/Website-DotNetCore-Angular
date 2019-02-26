using System;
using AutoMapper;
using Common.Database;
using Common.Web.Data;
using Common.Web.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website.Core.Common.Entities;
using Website.Core.Common.Infrastructure;
using Website.Core.Models;
using Website.Core.Repository;
using Website.Core.Repository.Interface;
using Website.Core.System.Services;

namespace Website.Core.System.Infrastructure
{
    public class SystemInitializer : IInitializer
    {
        public void InitializeDatabase(IServiceProvider serviceProvider)
        {
            var dbInitializer = new ApplicationDbInitializer();
            dbInitializer.InitializeDatabaseAsync<WebsiteDbContext, WebsiteUser>(serviceProvider);
        }

        public void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WebsiteDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Website.Core.Models")));

            services.AddScoped<IInitializerFactory, InitializerFactory>();

            services.AddIdentity<WebsiteUser, IdentityRole>(i =>
                {
                    i.Password.RequireDigit = false;
                    i.Password.RequiredLength = 6;
                    i.Password.RequireLowercase = false;
                    i.Password.RequireNonAlphanumeric = false;
                    i.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<WebsiteDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<TrIdentityErrorDescriber>();

            services.AddSingleton(_ => configuration);
            services.AddSingleton<ICachingEx, CachingEx>();

            services.AddAutoMapper();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());

            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPageComponentRepository, PageComponentRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();

            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IFileService, FileService>();
        }
    }
}