using System;

namespace Website.Core.Common
{
    public class KeyGenerator
    {
        public static string GetCacheKey<T>(string key, Guid? websiteId)
        {
            return $"{websiteId}_{typeof(T).Name}_{key}";
        }
    }
}