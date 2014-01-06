using Uddle.Message.Interface;

namespace Uddle.Controller.Interface
{
	interface IController
	{
        void Run(IMessage message);
	}
}
