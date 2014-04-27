using Uddle.GUI.Layout;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Strategy.Intro;
using Uddle.GUI.Layout.Strategy.Interface;
using Uddle.Dependency.Interface;
using System;
using Faj.Client.GUI.Layout.Interface;
using Faj.Client.GUI.Layout.Strategy.Player;

namespace Faj.Client.GUI.Layout
{
    class PlayerLayout : AbstractLayout, IPlayerLayout, IDependency
    {
        public event Action<IDependency> OnReleaseEvent;

        public PlayerLayout(ApplicationPlatform platform)
            : base(platform)
        {
        }

        protected override void InitializeStrategy(ApplicationPlatform platform)
        {
            var layoutStrategyFactory = new PlayerLayoutStrategyFactory(platform, this);
            layoutStrategy = layoutStrategyFactory.GetConcreteStrategy() as ILayoutStrategy;
        }
    }
}
