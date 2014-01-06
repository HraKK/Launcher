using Faj.Common.Model.Player.Structure;
using Faj.Common.Message.Content.Interface;

namespace Faj.Common.Message.Content
{
	class PlayerContent : IPlayerContent
	{
        readonly PlayerStructure playerStructure;

        public PlayerContent(PlayerStructure playerStructure)
        {
            this.playerStructure = playerStructure;
        }

        public PlayerStructure GetPlayerStructure()
        {
            return playerStructure;
        }
	}
}
