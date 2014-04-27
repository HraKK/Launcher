using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Interface;
using Uddle.Controller;
using Uddle.Message.Content.Interface;
using Faj.Common.Message.Content.Interface;

namespace Faj.Client.Controller
{
	class PlayerController : AbstractController
	{
        IPlayerModel playerModel;

        protected override void InitializeActions()
        {
            ActionDelegate load = Load;
            actions.Add("load", load);
            
        }

        void Load(IContent content)
        {
            var playerContent = content as IPlayerContent;
            var playerStructure = playerContent.GetPlayerStructure();

            GetPlayerModel().SetStructure(playerStructure);
        }

        public IPlayerModel GetPlayerModel()
        {
            if (playerModel == null)
            {
                var serviceProvider = ServiceProvider.Instance;
                playerModel = serviceProvider.GetService<IPlayerService>().GetPlayerModel();
            }

            return playerModel;
        }
	}
}
