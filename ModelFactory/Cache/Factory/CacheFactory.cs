using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Cache;
using ModelFactory.Cache.Core;
using ModelFactory.Model;
using ModelFactory.Model.Balance;
using ModelFactory.Model.Player;

namespace ModelFactory.Cache.Factory
{
    
    public class CacheFactory : ICacheFactory
    {
        private readonly ICoreTechContext _coreTechContext;
        private readonly IMemoryCache _memoryCache;
        private readonly IDictionary<Type, Func<ICacheItem>> _container = new Dictionary<Type, Func<ICacheItem>>();

        public CacheFactory(ICoreTechContext coreTechContext)
        {
            _coreTechContext = coreTechContext;
            _memoryCache = new MemoryCache(new MemoryCacheOptions() {SizeLimit = null});
            Register(_container);
        }

        private void Register ( IDictionary<Type, Func<ICacheItem>> container)
        {
            container.Add( typeof(IPlayerModel), () => new PlayerModelCache(this, _coreTechContext));
            container.Add( typeof(IPlayerBalanceModel), () => new PlayerBalanceCache(this, _coreTechContext));

        }
        public T Get<T>() where T : IModel
        {
            var model = _memoryCache.GetOrCreate(typeof(T), Create<T>);
            return model ;
        }

        public void Invalidate()
        {
            foreach (var item in _container)
            {
                _memoryCache.Remove(item.Key);
            }
        }

        private TItem Create<TItem>(ICacheEntry arg) where TItem : IModel
        {
            bool found = _container.TryGetValue(typeof(TItem), out var value);

            if (found)
            {
                ICacheEntryOption<TItem> cache = (ICacheEntryOption<TItem>) value?.Invoke();
                return cache.Create(arg);
            }
            else
            {
                foreach (KeyValuePair<Type, Func<ICacheItem>> item in _container)
                {
                    if (item.Key is TItem)
                    {
                        _container.Add(typeof(TItem) , item.Value);
                        Create<TItem>(arg);
                    }
                }
            }
            
            throw new Exception("Not found");
        }

    }
}