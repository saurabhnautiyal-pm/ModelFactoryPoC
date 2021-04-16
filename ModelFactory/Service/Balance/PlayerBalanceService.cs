using ModelFactory.Cache.Factory;
using ModelFactory.Model.Balance;

namespace ModelFactory.Service.Balance
{
    public class PlayerBalanceService : IPlayerBalanceService
    {
        private readonly ICacheFactory _cacheFactory;

        public PlayerBalanceService(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }

        public decimal GetBalance()
        {
            var balance = _cacheFactory.Get<IPlayerBalanceModel>();
            return balance.Balance;
        }
    }
}