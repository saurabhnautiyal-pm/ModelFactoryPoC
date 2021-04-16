using Microsoft.Extensions.Caching.Memory;
using ModelFactory.Cache.Factory;
using ModelFactory.Model.Player;
using ModelFactory.Service;
using ModelFactory.Service.Balance;
using ModelFactory.Service.Slot;
using Moq;
using NUnit.Framework;

namespace ModelFactory.UnitTest
{
    [TestFixture]
    public class CachFactoryUnitTest
    {
        private ICacheFactory _cacheFactory;
        [SetUp]
        public void Setup()
        {
            _cacheFactory = new CacheFactory();
        }

        [Test]
        public void TestGet_WillCreateNewModel_And_Return()
        {
            var playerModel = _cacheFactory.Get<IPlayerModel>();
            playerModel.Id = 1;
            playerModel.Name = "Saurabh Nautiyal";
            
            var playerModel1 = _cacheFactory.Get<IPlayerModel>();
            
            Assert.AreEqual(1 , playerModel1.Id);
            Assert.AreEqual("Saurabh Nautiyal" , playerModel1.Name);


        }
        
        [Test]
        public void TestGet_UpdateModelFromService()
        {
            ISlotMachineService slotMachineService = new SlotMachineService(_cacheFactory);
            slotMachineService.SetBalance(199);
            
            IPlayerBalanceService playerBalanceService = new PlayerBalanceService(_cacheFactory);
            decimal currentBalance = playerBalanceService.GetBalance();
            
            Assert.AreEqual(199,currentBalance);


        }
    }
}