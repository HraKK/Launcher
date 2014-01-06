using System.Collections.Generic;
using Uddle.Controller.Interface;
using Uddle.Message.Interface;
using Uddle.Router.Exception;
using Uddle.Router.Interface;

namespace Uddle.Router
{
	abstract class AbstractRouter : IRouter
	{
        protected Dictionary<string, IController> controllers = new Dictionary<string, IController>();

        public AbstractRouter()
        {
            InitializeControllers();
        }

        protected abstract void InitializeControllers();

        public void Route(IMessage message)
        {
            var controllerKey = message.GetController();
            IController controller;

            if (controllers.TryGetValue(controllerKey, out controller))
            {
                controller.Run(message);
                return;
            }

            throw new NotExistControllerException("Contoller doesn't exist: " + controllerKey);
        }
	}
}
