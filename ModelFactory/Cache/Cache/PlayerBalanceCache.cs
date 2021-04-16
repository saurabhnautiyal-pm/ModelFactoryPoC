using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Core;
using ModelFactory.Model.Balance;

namespace ModelFactory.Cache.Cache
{
    public class PlayerBalanceCache : ICacheEntryOption <IPlayerBalanceModel> , ICacheItem
    {
        public PlayerBalanceCache()
        {
            AbsoluteExpiryTime = 10;
            SlidingExpiryTime = 20;
        }

        public IPlayerBalanceModel Create(ICacheEntry item)
        {
            item.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(AbsoluteExpiryTime);
            item.SlidingExpiration = TimeSpan.FromMinutes( SlidingExpiryTime);
            
            IPlayerBalanceModel balance = new PlayerBalanceModel();
            return balance;
        }

        public float AbsoluteExpiryTime { get; set; }
        public float SlidingExpiryTime { get; set; }
        
    }
}      