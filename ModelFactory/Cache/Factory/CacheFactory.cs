using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Core;
using ModelFactory.Cache.Registration;
using ModelFactory.Model;

namespace ModelFactory.Cache.Factory
{
    
    public class CacheFactory : ICacheFactory
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDictionary<Type, Func<ICacheItem>> _container = new Dictionary<Type, Func<ICacheItem>>();

        public CacheFactory()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions() {SizeLimit = null});
            this.Register(_container);
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
            _container.TryGetValue(typeof(TItem), out var value);
            ICacheEntryOption<TItem> cache = (ICacheEntryOption<TItem>) value?.Invoke();
            return cache.Create(arg);
        }

    }
}