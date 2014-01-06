using Uddle.Router;
using Faj.Client.Controller;

namespace Faj.Client.Router
{
	class ClientRouter : AbstractRouter
	{
        protected override void InitializeControllers()
        {
            controllers.Add("player", new PlayerController());
        }
	}
}
