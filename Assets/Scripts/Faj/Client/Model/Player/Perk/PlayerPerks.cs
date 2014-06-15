using System.Collections.Generic;
using Faj.Client.Model.Player.Perk.Interface;
using Faj.Client.Model.Player.Interface;
using Uddle.Static.Service.Interface;
using Uddle.Service;

namespace Faj.Client.Model.Player.Perk
{
	class PlayerPerks : IPlayerPerks
	{
        readonly IPlayerModel playerModel;

        public PlayerPerks(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public List<string> GetPerks()
        {
            return playerModel.GetPlayerStructure().perks;
        }

        public bool IsPerk(string perk)
        {
            return playerModel.GetPlayerStructure().perks.Contains(perk);
        }
	}
}
