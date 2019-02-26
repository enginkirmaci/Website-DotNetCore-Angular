using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Website.Core.Common.Infrastructure;
using Website.Core.Common.Interfaces;

namespace Website.Component.PageList.Infrastructure
{
    public class PageListInitializer : IInitializer
    {
        public void InitializeDatabase(IServiceProvider serviceProvider)
        {
        }

        public void Initialize(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IPageComponent, PageListComponent>();
        }
    }
}