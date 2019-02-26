using System;

namespace Website.Core.Common.Infrastructure
{
    public interface IInitializerFactory
    {
        void InitializeApplicationDatabases(IServiceProvider applicationService);
    }
}