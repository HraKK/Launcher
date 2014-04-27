using Uddle.GUI.Layout;
using Uddle.Config.Interface;
using Faj.Client.GUI.Layout.Strategy.Intro;
using Uddle.GUI.Layout.Strategy.Interface;
using Uddle.Dependency.Interface;
using System;
using Faj.Client.GUI.Layout.Interface;
using Faj.Client.GUI.Layout.Strategy.SelectLevel;
using Faj.Common.Model.Static.Level.Collection.Interface;
using Uddle.Static.Service.Interface;
using Uddle.Service;
using System.Collections.Generic;
using Faj.Client.Model.Player.Interface;
using Faj.Client.Model.Player.Service.Interface;

namespace Faj.Client.GUI.Layout
{
    class SelectLevelLayout : AbstractLayout, ISelectLevelLayout, IDependency
    {
        public event Action<IDependency> OnReleaseEvent;

        ILevelCollection levelCollection;
        IPlayerModel playerModel;

        public SelectLevelLayout(ApplicationPlatform platform)
            : base(platform)
        {
        }

        protected override void InitializeStrategy(ApplicationPlatform platform)
        {
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            levelCollection = staticContainerService.GetStaticCollection<ILevelCollection>("levels");
            var layoutStrategyFactory = new SelectLevelLayoutStrategyFactory(platform, this);
            layoutStrategy = layoutStrategyFactory.GetConcreteStrategy() as ILayoutStrategy;
        }

        public ILevelCollection GetLevels()
        {
            return levelCollection;
        }

        public Dictionary<string, int> GetOpenedLevels()
        {
            return GetPlayerModel().GetLevels().GetOpenedLevels();
        }

        protected IPlayerModel GetPlayerModel()
        {
            if (null == playerModel)
            {
                var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
                playerModel = playerService.GetPlayerModel();
            }

            return playerModel;
        }
    }
}
