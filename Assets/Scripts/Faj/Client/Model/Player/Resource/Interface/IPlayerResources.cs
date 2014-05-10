using System.Collections.Generic;

namespace Faj.Client.Model.Player.Resource.Interface
{
	interface IPlayerResources
	{
        int GetResource(string resource);
        Dictionary<string, int> GetResources();
        bool IsEnoughResources(Dictionary<string, int> resources);
	}
}
