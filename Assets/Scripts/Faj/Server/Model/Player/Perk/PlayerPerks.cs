using Faj.Server.Model.Player.Perk.Interface;
using System.Collections.Generic;
using Faj.Server.Model.Player.Interface;
using System.Runtime.CompilerServices;

namespace Faj.Server.Model.Player.Perk
{
	class PlayerPerks : IPlayerPerks
	{
        readonly IPlayerModel playerModel;

        public PlayerPerks(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<string> GetPerks()
        {
            return playerModel.GetPlayerStructure().perks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool IsPerk(string perk)
        {
            return playerModel.GetPlayerStructure().perks.Contains(perk);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddPerk(string perk)
        {
            if (IsPerk(perk))
            {
                return;
            }

            playerModel.GetPlayerStructure().perks.Add(perk);
        }
	}
}
