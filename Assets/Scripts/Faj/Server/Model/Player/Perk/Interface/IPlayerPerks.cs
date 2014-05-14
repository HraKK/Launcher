using System.Collections.Generic;

namespace Faj.Server.Model.Player.Perk.Interface
{
	interface IPlayerPerks
	{
        void AddPerk(string perk);
        List<string> GetPerks();
        bool IsPerk(string perk);
	}
}
