using System;
using System.Collections.Generic;
using ModelFactory.Cache.Cache;
using ModelFactory.Cache.Core;
using ModelFactory.Cache.Factory;
using ModelFactory.Model;
using ModelFactory.Model.Balance;
using ModelFactory.Model.Player;

namespace ModelFactory.Cache.Registration
{
    public static class CacheRegistration
    {
        public static void Register (this CacheFactory cacheFactory,   IDictionary<Type, Func<ICacheItem>> container)
        {
            container.Add( typeof(IPlayerModel), () => new PlayerModelCache());
            container.Add( typeof(IPlayerBalanceModel), () => new PlayerBalanceCache());

        }
    }
}