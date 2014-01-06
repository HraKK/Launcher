using Faj.Server.Router.Service.Interface;
using Uddle.Router.Interface;
using Uddle.Message.Interface;

namespace Faj.Server.Router.Service
{
	class ServerRouterService : IServerRouterService
	{
        readonly IRouter router;

        public ServerRouterService(IRouter router)
        {
            this.router = router;
        }

        public void Route(IMessage message)
        {
            router.Route(message);
        }
	}
}
