using Microsoft.Extensions.Configuration;
using System;

namespace Website.Core.System.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public ConfigurationService(IConfiguration configuration)
        {
            WebsiteGuid = new Guid(configuration["Settings:Website"]);
        }

        public Guid WebsiteGuid { get; set; }
    }
}