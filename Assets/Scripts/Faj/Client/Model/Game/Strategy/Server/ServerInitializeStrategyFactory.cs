using Uddle.Strategy.Interface;
using Uddle.Config.Interface;

namespace Faj.Client.Model.Game.Strategy.Server
{
	class ServerInitializeStrategyFactory: IStrategyFactory
	{
        ApplicationPlatform platform;

        public ServerInitializeStrategyFactory(ApplicationPlatform platform)
        {
            this.platform = platform;
        }

        public IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                case ApplicationPlatform.WEB :
                    return new EmptyServerInitializeStrategy();
                default :
                    return new BaseServerInitializeStrategy();
               
            }
        }
	}
}