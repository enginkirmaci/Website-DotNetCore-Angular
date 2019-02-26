using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Website.Core.Common.Infrastructure;

namespace Website.Core.Application.Infrastructure
{
    public class ApplicationInitializer : IInitializer
    {
        public void InitializeDatabase(IServiceProvider serviceProvider)
        {
        }

        public void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IPageBuilder, PageBuilder>();
            services.AddScoped<IApplicationContext, ApplicationContext>();
        }
    }
}