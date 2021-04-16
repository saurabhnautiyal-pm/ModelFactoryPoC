using System;
using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Core;
using ModelFactory.Model;

namespace ModelFactory.Cache.Cache
{
    public abstract class Cache <T> : ICacheEntryOption <T> , ICacheItem where T : IModel
    {

        public T Create(ICacheEntry item)
        {
            item.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(AbsoluteExpiryTime);
            item.SlidingExpiration = TimeSpan.FromMinutes(SlidingExpiryTime);

            T model = CreateModel();
            item.Value = model;
            return model;
        }

        protected abstract T CreateModel();
        public virtual float AbsoluteExpiryTime { get; set; } = 10;
        public virtual float SlidingExpiryTime { get; set; } = 20;
    }
}