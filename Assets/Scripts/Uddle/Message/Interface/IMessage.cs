using Uddle.Message.Content.Interface;

namespace Uddle.Message.Interface
{
	interface IMessage
	{
        string GetController();
        string GetAction();
        IContent GetContent();
	}
}
