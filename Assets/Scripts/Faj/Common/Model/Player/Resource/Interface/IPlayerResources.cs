using System.Collections.Generic;

namespace Faj.Common.Model.Player.Resource.Interface
{
	interface IPlayerResources
	{
        Dictionary<string, int> GetResources();
        bool IsEnoughResources(Dictionary<string, int> resources);
        void AwardResources(Dictionary<string, int> resources);
        void PayResources(Dictionary<string, int> resources);
	}
}
