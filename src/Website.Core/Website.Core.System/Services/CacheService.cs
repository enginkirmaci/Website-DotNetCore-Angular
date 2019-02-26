using Common.Web.Data;
using System.Collections.Generic;
using Website.Core.Common;

namespace Website.Core.System.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICachingEx _cachingEx;
        private readonly IConfigurationService _configurationService;
        private List<string> CacheKeys { get; set; }

        public CacheService(
            ICachingEx cachingEx,
            IConfigurationService configurationService)
        {
            _cachingEx = cachingEx;
            _configurationService = configurationService;

            CacheKeys = new List<string>();
        }

        public void Add<T>(string key, T value)
        {
            var cacheKey = KeyGenerator.GetCacheKey<T>(key, _configurationService.WebsiteGuid);

            CacheKeys.Add(cacheKey);
            _cachingEx.Add(cacheKey, value);
        }

        public void Remove<T>(string key)
        {
            var cacheKey = KeyGenerator.GetCacheKey<T>(key, _configurationService.WebsiteGuid);

            CacheKeys.Remove(cacheKey);
            _cachingEx.Remove(cacheKey);
        }

        public bool Exists<T>(string key)
        {
            var cacheKey = KeyGenerator.GetCacheKey<T>(key, _configurationService.WebsiteGuid);

            return _cachingEx.Exists(cacheKey);
        }

        public T Get<T>(string key)
        {
            var cacheKey = KeyGenerator.GetCacheKey<T>(key, _configurationService.WebsiteGuid);

            return _cachingEx.Get<T>(cacheKey);
        }
    }
}