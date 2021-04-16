using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Core;
using ModelFactory.Model.Player;

namespace ModelFactory.Cache.Cache
{
    public class PlayerModelCache : ICacheEntryOption <IPlayerModel> , ICacheItem
    {
        public PlayerModelCache()
        {
            AbsoluteExpiryTime = 10;
            SlidingExpiryTime = 20;
        }
        public IPlayerModel Create(ICacheEntry item) 
        {
            item.Value = new PlayerModel();
            return (IPlayerModel) item.Value;
        }

        public float AbsoluteExpiryTime { get; set; }
        public float SlidingExpiryTime { get; set; }
        
    }
}