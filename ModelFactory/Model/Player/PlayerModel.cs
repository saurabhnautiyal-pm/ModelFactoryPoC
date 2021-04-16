using ModelFactory.Cache.Factory;

namespace ModelFactory.Model.Player
{
    public class PlayerModel : IPlayerModel
    {
        private readonly ICacheFactory _cacheFactory;
        private readonly INetworkReachability _networkReachability;

        public PlayerModel(ICacheFactory cacheFactory, INetworkReachability networkReachability)
        {
            _cacheFactory = cacheFactory;
            _networkReachability = networkReachability;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}