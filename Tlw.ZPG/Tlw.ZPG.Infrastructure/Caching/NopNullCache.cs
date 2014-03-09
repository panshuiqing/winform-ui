namespace Tlw.ZPG.Infrastructure.Caching
{
    public partial class NopNullCache : ICacheManager
    {
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        public virtual void Set(string key, object data, int minute)
        {
        }

        public bool IsSet(string key)
        {
            return false;
        }

        public virtual void Remove(string key)
        {
        }

        public virtual void Clear()
        {
        }
    }
}