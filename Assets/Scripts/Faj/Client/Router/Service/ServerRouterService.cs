using Uddle.Router.Interface;
using Uddle.Message.Interface;
using Faj.Client.Router.Service.Interface;

namespace Faj.Client.Router.Service
{
	class ClientRouterService : IClientRouterService
	{
        readonly IRouter router;

        public ClientRouterService(IRouter router)
        {
            this.router = router;
        }

        public void Route(IMessage message)
        {
            router.Route(message);
        }
	}
}
