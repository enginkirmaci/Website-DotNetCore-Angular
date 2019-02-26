using System;
using System.Collections.Generic;
using Common.Utilities.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Website.Core.Common.Infrastructure
{
    public class InitializerFactory : IInitializerFactory
    {
        private readonly IEnumerable<IInitializer> _initializers;

        public InitializerFactory(IEnumerable<IInitializer> initializers)
        {
            _initializers = initializers;
        }

        public static void InitializeApplicationServices(IConfiguration configuration, IServiceCollection services)
        {
            var assemblies = AssemblyScanner.Scan("Website.*.dll");
            var initializers = assemblies.GetTypesImplementing<IInitializer>();

            foreach (var init in initializers)
            {
                var instance = Activator.CreateInstance(init);

                if (instance is IInitializer initalizerInstance)
                {
                    initalizerInstance.Initialize(configuration, services);

                    services.AddScoped(provider => initalizerInstance);
                }
            }
        }

        public void InitializeApplicationDatabases(IServiceProvider applicationService)
        {
            foreach (var initializer in _initializers)
            {
                initializer.InitializeDatabase(applicationService);
            }
        }
    }
}