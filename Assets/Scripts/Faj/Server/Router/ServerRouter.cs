using Uddle.Router;
using Faj.Server.Controller;

namespace Faj.Server.Router
{
	class ServerRouter : AbstractRouter
	{
        protected override void InitializeControllers()
        {
            controllers.Add("initialize", new InitializeController());
        }
	}
}
