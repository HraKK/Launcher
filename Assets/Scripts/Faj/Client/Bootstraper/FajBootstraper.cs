using Uddle.Bootstrap;
using Uddle.Config.Interface;
using Uddle.Service;
using Faj.Client.Dao;
using Faj.Client.Dao.Interface;
using Faj.Client.Router.Strategy;

namespace Faj.Client.Bootstrap
{
    class FajBootstraper : CoreBootstraper
	{
        public FajBootstraper(IApplicationConfig applicationConfig)
            : base(applicationConfig)
        {
        }

        protected override void InitComponents()
        {
            var serviceProvider = ServiceProvider.Instance;

            var daoFactory = new DaoFactory(applicationConfig.GetPlatform());
            serviceProvider.SetService<IDaoFactory>(daoFactory);

            var routerStrategyFactory = new RouterStrategyFactory(applicationConfig.GetPlatform());
            var routerStrategy = routerStrategyFactory.GetConcreteStrategy();
            routerStrategy.DoStrategy();
        }
	}
}
