using Uddle.Controller.Interface;
using System.Collections.Generic;
using Uddle.Controller.Exception;
using Uddle.Message.Content.Interface;
using Uddle.Message.Interface;

namespace Uddle.Controller
{
	abstract class AbstractController : IController
	{
        protected Dictionary<string, ActionDelegate> actions = new Dictionary<string, ActionDelegate>();
        protected delegate void ActionDelegate(IContent message);

        public AbstractController()
        {
            InitializeActions();
        }

        protected abstract void InitializeActions();

        public void Run(IMessage message)
        {
            var action = message.GetAction();
            ActionDelegate actionDelegate;

            if (actions.TryGetValue(action, out actionDelegate))
            {
                actionDelegate(message.GetContent());
                return;
            }

            throw new NotExistActionException("Action doesn't exist: " + action);
        }
	}
}
