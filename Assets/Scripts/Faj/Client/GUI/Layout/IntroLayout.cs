using Uddle.GUI.Layout;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Strategy.Intro;
using Uddle.GUI.Layout.Strategy.Interface;

namespace Faj.Client.GUI.Layout
{
    class IntroLayout : AbstractLayout
	{
        public IntroLayout(ApplicationPlatform platform)
            : base(platform)
        {
        }

        protected override void InitializeStrategy(ApplicationPlatform platform)
        {
            var layoutStrategyFactory = new IntroLayoutStrategyFactory(platform);
            layoutStrategy = layoutStrategyFactory.GetConcreteStrategy() as ILayoutStrategy;
        }
	}
}
