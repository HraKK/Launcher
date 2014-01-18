using Uddle.Strategy.Interface;
using Uddle.Config.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
	class IntroLayoutStrategyFactory : IStrategyFactory
	{
        ApplicationPlatform platform;

        public IntroLayoutStrategyFactory(ApplicationPlatform platform)
        {
            this.platform = platform;
        }

        public IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSIntroLayoutStrategy();
            }
        }
	}
}
