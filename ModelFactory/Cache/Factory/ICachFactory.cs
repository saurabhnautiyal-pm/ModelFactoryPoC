using ModelFactory.Model;

namespace ModelFactory.Cache.Factory
{
    public interface ICacheFactory
    {
        T Get<T>() where T : IModel;
        void Invalidate();
    }
} 