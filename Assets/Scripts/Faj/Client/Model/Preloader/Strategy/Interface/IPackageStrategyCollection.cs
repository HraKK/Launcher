using Uddle.Strategy.Interface;

namespace Faj.Client.Model.Preloader.Strategy.Interface
{
	interface IPackageStrategyCollection
	{
        IStrategy GetStrategy(string package);
	}
}
