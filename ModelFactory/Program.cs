using System;
using System.Configuration;
using System.Reflection;
using ModelFactory.Cache.Factory;
using ModelFactory.Model.Player;

namespace ModelFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheFactory factory = new CacheFactory();
            var model = factory.Get<IPlayerModel>();
            
            model.Id = 10;
            model.Name = "Saurabh Nautiyal";
            
            var model2 = factory.Get<IPlayerModel>();
            
            Console.WriteLine($"Current balance is {model2.Name}");

        }
    }
}