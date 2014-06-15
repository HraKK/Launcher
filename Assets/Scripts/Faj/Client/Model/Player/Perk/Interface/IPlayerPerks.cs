using System.Collections.Generic;

namespace Faj.Client.Model.Player.Perk.Interface
{
	interface IPlayerPerks
	{
        List<string> GetPerks();
        bool IsPerk(string perk);
	}
}
