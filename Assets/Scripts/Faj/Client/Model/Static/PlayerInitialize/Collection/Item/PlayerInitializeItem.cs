using Faj.Client.Model.Static.PlayerInitialize.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Client.Model.Static.PlayerInitialize.Collection.Item
{
    struct PlayerInitializeItem : IPlayerInitializeItem
	{
        readonly Dictionary<string, int> resources;

        public PlayerInitializeItem(Dictionary<string, int> resources)
        {
            this.resources = resources;
        }

        public Dictionary<string, int> GetResources()
        {
            return resources;
        }
	}
}
