using Uddle.GUI.Layout;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Strategy.Intro;
using Uddle.GUI.Layout.Strategy.Interface;
using Uddle.Dependency.Interface;
using System;
using Faj.Client.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout
{
    class IntroLayout : AbstractLayout, IIntroLayout, IDependency
	{
        public event Action<IDependency> OnReleaseEvent;

        public IntroLayout(ApplicationPlatform platform)
            : base(platform)
        {
        }

        protected override void InitializeStrategy(ApplicationPlatform platform)
        {
            var layoutStrategyFactory = new IntroLayoutStrategyFactory(platform, this);
            layoutStrategy = layoutStrategyFactory.GetConcreteStrategy() as ILayoutStrategy;
        }

        public void Release()
        {
            if (null != OnReleaseEvent)
            {
                OnReleaseEvent(this);
            }
        }
	}
}
