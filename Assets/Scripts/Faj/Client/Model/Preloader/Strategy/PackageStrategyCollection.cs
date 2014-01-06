using Uddle.Strategy.Interface;
using System.Collections.Generic;
using Faj.Client.Model.Preloader.Strategy.Interface;

namespace Faj.Client.Model.Preloader.Strategy
{
    class PackageStrategyCollection : IPackageStrategyCollection
	{
        Dictionary<string, IStrategy> packagesStrategy = new Dictionary<string, IStrategy>();

        public PackageStrategyCollection()
        {
            packagesStrategy.Add("static", new StaticPackageStrategy());
        }

        public IStrategy GetStrategy(string package)
        {
            IStrategy strategy;

            packagesStrategy.TryGetValue(package, out strategy);

            return strategy;
        }
	}
}
