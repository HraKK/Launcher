using Uddle.Strategy.Interface;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Preloader
{
	class PreloaderLayoutStrategyFactory : IStrategyFactory
	{
        ApplicationPlatform platform;
        IPreloaderLayout preloaderLayout;

        public PreloaderLayoutStrategyFactory(ApplicationPlatform platform, IPreloaderLayout preloaderLayout)
        {
            this.platform = platform;
            this.preloaderLayout = preloaderLayout;
        }

        public IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSPreloaderLayoutStrategy(preloaderLayout);
            }
        }
	}
}
