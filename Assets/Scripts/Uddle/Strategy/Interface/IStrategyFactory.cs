namespace Uddle.Strategy.Interface
{
	interface IStrategyFactory
	{
        IStrategy GetConcreteStrategy();
	}
}
