using ModelFactory.Cache.Factory;
using ModelFactory.Model.Player;

namespace ModelFactory.Cache.Cache
{
    public class PlayerModelCache : Cache<IPlayerModel>
    {
        private readonly ICacheFactory _factory;
        private readonly ICoreTechContext _coreTechContext;

        public PlayerModelCache(ICacheFactory factory , ICoreTechContext coreTechContext)
        { 
            _factory = factory;
            _coreTechContext = coreTechContext;
          
        }

        protected override IPlayerModel CreateModel()
        {
            return new PlayerModel(_factory, _coreTechContext.NetworkReachability);
        }
    }
}