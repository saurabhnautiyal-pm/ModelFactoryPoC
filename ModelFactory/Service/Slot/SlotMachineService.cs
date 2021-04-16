using ModelFactory.Cache.Factory;
using ModelFactory.Model.Balance;

namespace ModelFactory.Service.Slot
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly ICacheFactory _cacheFactory;

        public SlotMachineService(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }

        public void SetBalance(decimal balance)
        {
            var balanceModel = _cacheFactory.Get<IPlayerBalanceModel>();
            balanceModel.Balance = balance;
            
        }
    }
}