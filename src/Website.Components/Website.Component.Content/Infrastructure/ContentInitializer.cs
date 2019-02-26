using AutoMapper;
using Common.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Website.Component.Content.Data;
using Website.Component.Content.Entities;
using Website.Core.Common.Infrastructure;
using Website.Core.Common.Interfaces;

namespace Website.Component.Content.Infrastructure
{
    public class ContentInitializer : IInitializer
    {
        public void InitializeDatabase(IServiceProvider serviceProvider)
        {
            var dbInitializer = new ApplicationDbInitializer();
            dbInitializer.InitializeDatabaseAsync<ContentDb>(serviceProvider);
        }

        public void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContentDb>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddScoped<IPageComponent, ContentComponent>();
            services.AddScoped<IContentRepository, ContentRepository>();

            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }
    }
}