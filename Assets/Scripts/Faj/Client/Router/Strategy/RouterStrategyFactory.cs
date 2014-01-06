using Uddle.Config.Interface;
using Uddle.Strategy.Interface;

namespace Faj.Client.Router.Strategy
{
	class RouterStrategyFactory : IStrategyFactory
	{
        ApplicationPlatform platform;

        public RouterStrategyFactory(ApplicationPlatform platform)
        {
            this.platform = platform;
        }

        public IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                case ApplicationPlatform.WEB :
                    return new ClientOnlyRouterStrategy();
                default :
                    return new ClientAndServerRouterStrategy();
               
            }
        }
	}
}
