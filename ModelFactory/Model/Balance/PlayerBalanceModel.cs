using ModelFactory.Cache.Factory;

namespace ModelFactory.Model.Balance
{
    public class PlayerBalanceModel : IPlayerBalanceModel
    {
        private readonly ICacheFactory _cacheFactory;
        private readonly IAnalyticsEventService _analyticsEventService;

        public PlayerBalanceModel(ICacheFactory  cacheFactory , IAnalyticsEventService analyticsEventService)
        {
            _cacheFactory = cacheFactory;
            _analyticsEventService = analyticsEventService;
        }

        public int PlayerId { get; set; }
        public decimal Balance { get; set; }
    }
}