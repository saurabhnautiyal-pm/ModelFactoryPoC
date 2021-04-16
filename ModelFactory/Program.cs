using System;
using ModelFactory.Cache.Factory;
using ModelFactory.Model.Player;

namespace ModelFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoreTechContext context = new CoreTechContext();
            CacheFactory factory = new CacheFactory(context);
            var model = factory.Get<IPlayerModel>();
            
            model.Id = 10;
            model.Name = "Saurabh Nautiyal";
            
            var model2 = factory.Get<IPlayerModel>();
            
            Console.WriteLine($" {model2.Id} {model2.Name}");

        }
    }
}