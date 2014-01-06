using Uddle.Message.Interface;
using Uddle.Message.Content.Interface;

namespace Uddle.Message
{
    class SimpleMessage : IMessage
	{
        protected readonly string controller;
        protected readonly string action;
        protected readonly IContent content;

        public SimpleMessage(string controller, string action, IContent content)
        {
            this.controller = controller;
            this.action = action;
            this.content = content;
        }

        public string GetController()
        {
            return controller;
        }
        public string GetAction()
        {
            return action;
        }

        public IContent GetContent()
        {
            return content;
        }
	}
}
