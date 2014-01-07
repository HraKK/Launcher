using Uddle.GUI.Layout;
using Uddle.Model.Preloader.Interface;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Strategy;
using Faj.Client.GUI.Layout.Interface;
using Uddle.GUI.Layout.Strategy.Interface;
namespace Faj.Client.GUI.Layout
{
	class PreloaderLayout : AbstractLayout, IPreloaderLayout
	{
        IPreloaderModel preloaderModel;

        public PreloaderLayout(IPreloaderModel preloaderModel, ApplicationPlatform platform) : base(platform)
        {
            this.preloaderModel = preloaderModel;
        }

        protected override void InitializeStrategy(ApplicationPlatform platform)
        {
            var layoutStrategyFactory = new PreloaderLayoutStrategyFactory(platform, this);
            layoutStrategy = layoutStrategyFactory.GetConcreteStrategy() as ILayoutStrategy;
        }
	}
}
