using Uddle.Strategy.Interface;

namespace Uddle.GUI.Layout.Strategy.Interface
{
	interface ILayoutStrategy : IStrategy
	{
        void DoInitializeStrategy();
        void DoDisappearStrategy();
	}
}
