using Uddle.Strategy.Interface;
using Uddle.GUI.Layout.Strategy;
using Faj.Client.GUI.Layout.Interface;
using Uddle.Config.Interface;
using Uddle.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.SelectLevel
{
    class SelectLevelLayoutStrategyFactory : AbstractLayoutStrategyFactory
    {
        public SelectLevelLayoutStrategyFactory(ApplicationPlatform platform, ILayout layout)
            : base(platform, layout)
        {
        }

        public override IStrategy GetConcreteStrategy()
        {
            switch (platform)
            {
                default:
                    return new IoSSelectLevelLayoutStrategy(layout as ISelectLevelLayout);
            }
        }
    }
}
