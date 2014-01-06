using Uddle.Strategy.Interface;
using Faj.Server.Router;
using Faj.Server.Router.Service;
using Uddle.Service;
using Faj.Server.Router.Service.Interface;
using Faj.Client.Router.Service.Interface;
using Faj.Client.Router.Service;

namespace Faj.Client.Router.Strategy
{
	class ClientAndServerRouterStrategy : IStrategy
	{
        public void DoStrategy()
        {
            InitializeClientRoute();
            InitializeServerRoute();
        }

        void InitializeClientRoute()
        {
            var clientRouter = new ClientRouter();
            var clientRouterService = new ClientRouterService(clientRouter);
            ServiceProvider.Instance.SetService<IClientRouterService>(clientRouterService);
        }

        void InitializeServerRoute()
        {
            var serverRouter = new ServerRouter();
            var serverRouterService = new ServerRouterService(serverRouter);
            ServiceProvider.Instance.SetService<IServerRouterService>(serverRouterService);
        }
	}
}
