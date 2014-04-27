using Uddle.GUI.Layout.Strategy;
using Uddle.Strategy.Interface;
using Faj.Client.GUI.Layout.Interface;
using Faj.Client.GUI.Layout.Strategy.Intro;
using Uddle.Config.Interface;
using Uddle.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Player
{
    class PlayerLayoutStrategyFactory : AbstractLayoutStrategyFactory
    {
        public PlayerLayoutStrategyFactory(ApplicationPlatform platform, ILayout layout)
            : base(platform, layout)
        {
        }

        public override IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSPlayerLayoutStrategy(layout as IPlayerLayout);
            }
        }
    }
}
