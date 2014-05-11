using Faj.Client.Model.Player.Quest.Interface;
using Faj.Client.Model.Player.Interface;

namespace Faj.Client.Model.Player.Quest
{
	class PlayerQuests : IPlayerQuests
	{        
        readonly IPlayerModel playerModel;

        public PlayerQuests(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }
	}
}