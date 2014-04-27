using Uddle.Strategy.Interface;
using Uddle.Config.Interface;
using Uddle.GUI.Layout.Interface;

namespace Uddle.GUI.Layout.Strategy
{
    abstract class AbstractLayoutStrategyFactory : IStrategyFactory
    {
        protected readonly ApplicationPlatform platform;
        protected readonly ILayout layout;

        public AbstractLayoutStrategyFactory(ApplicationPlatform platform, ILayout layout)
        {
            this.platform = platform;
            this.layout = layout;
        }

        public abstract IStrategy GetConcreteStrategy();
    }
}
