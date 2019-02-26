using System;

namespace Website.Core.System.Services
{
    public interface IConfigurationService
    {
        Guid WebsiteGuid { get; set; }
    }
}