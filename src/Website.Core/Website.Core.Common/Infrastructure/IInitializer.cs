using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Website.Core.Common.Infrastructure
{
    public interface IInitializer
    {
        void InitializeDatabase(IServiceProvider serviceProvider);

        void Initialize(IConfiguration configuration, IServiceCollection services);
    }
}