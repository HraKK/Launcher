using Uddle.Service.Interface;
using Uddle.Message.Interface;

namespace Faj.Server.Router.Service.Interface
{
	interface IServerRouterService : IService
	{
        void Route(IMessage message);
	}
}
