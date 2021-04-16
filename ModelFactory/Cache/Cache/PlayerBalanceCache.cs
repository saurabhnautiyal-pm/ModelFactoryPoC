using ModelFactory.Cache.Factory;
using ModelFactory.Model.Balance;

namespace ModelFactory.Cache.Cache
{
    public class PlayerBalanceCache : Cache <IPlayerBalanceModel>
    {
        private readonly ICacheFactory _factory;
        private readonly ICoreTechContext _coreTechContext;

        public PlayerBalanceCache(ICacheFactory factory, ICoreTechContext coreTechContext)
        {
            _factory = factory;
            _coreTechContext = coreTechContext;
        }

        protected override IPlayerBalanceModel CreateModel()
        {
            IPlayerBalanceModel balance = new PlayerBalanceModel(_factory, _coreTechContext.AnalyticsEvents);
            return balance;
        }
    }
}      