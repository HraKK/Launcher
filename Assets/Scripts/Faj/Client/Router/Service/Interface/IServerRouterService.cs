using Uddle.Service.Interface;
using Uddle.Message.Interface;

namespace Faj.Client.Router.Service.Interface
{
	interface IClientRouterService : IService
	{
        void Route(IMessage message);
	}
}
