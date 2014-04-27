using Uddle.GUI.Layout.Strategy;
using Uddle.Strategy.Interface;
using Faj.Client.GUI.Layout.Interface;
using Uddle.Config.Interface;
using Uddle.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
    class IntroLayoutStrategyFactory : AbstractLayoutStrategyFactory
	{
        public IntroLayoutStrategyFactory(ApplicationPlatform platform, ILayout layout)
            : base(platform, layout)
        {
        }

        public override IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSIntroLayoutStrategy(layout as IIntroLayout);
            }
        }
	}
}
