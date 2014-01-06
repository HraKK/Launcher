using Uddle.Message.Interface;

namespace Uddle.Router.Interface
{
	interface IRouter
	{
        void Route(IMessage message);
	}
}
