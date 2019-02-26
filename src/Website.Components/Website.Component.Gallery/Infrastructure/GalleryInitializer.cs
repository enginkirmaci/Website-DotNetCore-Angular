using System;
using System.Reflection;
using AutoMapper;
using Common.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website.Component.Gallery.Data;
using Website.Component.Gallery.Entities;
using Website.Core.Common.Infrastructure;
using Website.Core.Common.Interfaces;

namespace Website.Component.Gallery.Infrastructure
{
    public class GalleryInitializer : IInitializer
    {
        public void InitializeDatabase(IServiceProvider serviceProvider)
        {
            var dbInitializer = new ApplicationDbInitializer();
            dbInitializer.InitializeDatabaseAsync<GalleryDb>(serviceProvider);
        }

        public void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<GalleryDb>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddScoped<IPageComponent, GalleryComponent>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();

            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }
    }
}