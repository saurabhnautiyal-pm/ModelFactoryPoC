namespace ModelFactory.Cache.Core
{
    public interface ICacheItem
    {
        float AbsoluteExpiryTime { get; set; }
        float SlidingExpiryTime { get; set; }
    }
}