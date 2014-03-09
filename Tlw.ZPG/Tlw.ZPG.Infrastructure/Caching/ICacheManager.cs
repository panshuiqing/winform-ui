namespace Tlw.ZPG.Infrastructure.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set(string key, object data, int minute);

        bool IsSet(string key);

        void Remove(string key);

        void Clear();
    }
}
