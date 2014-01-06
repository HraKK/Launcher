using Uddle.Message.Interface;
using Uddle.Message.Content.Interface;

namespace Uddle.Message
{
	class EmptyMessage : IMessage
	{
        protected readonly string controller;
        protected readonly string action;

        public EmptyMessage(string controller, string action)
        {
            this.controller = controller;
            this.action = action;
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
            return null;
        }
	}
}
