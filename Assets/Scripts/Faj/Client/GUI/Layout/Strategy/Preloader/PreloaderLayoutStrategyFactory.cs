using Uddle.Strategy.Interface;
using Uddle.GUI.Layout.Strategy;
using Faj.Client.GUI.Layout.Interface;
using Uddle.Config.Interface;
using Uddle.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Preloader
{
    class PreloaderLayoutStrategyFactory : AbstractLayoutStrategyFactory
	{
        public PreloaderLayoutStrategyFactory(ApplicationPlatform platform, ILayout layout)
            : base(platform, layout)
        {
        }

        public override IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSPreloaderLayoutStrategy(layout as IPreloaderLayout);
            }
        }
	}
}
