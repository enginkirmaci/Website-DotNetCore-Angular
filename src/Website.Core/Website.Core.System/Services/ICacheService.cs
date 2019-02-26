namespace Website.Core.System.Services
{
    public interface ICacheService
    {
        void Add<T>(string key, T value);

        void Remove<T>(string key);

        bool Exists<T>(string key);

        T Get<T>(string key);
    }
}