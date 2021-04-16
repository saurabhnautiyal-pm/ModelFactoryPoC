using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Model;

namespace ModelFactory.Cache.Core
{
    public interface ICacheEntryOption <out T> where T : IModel
    {
        T Create(ICacheEntry item);
    }
}