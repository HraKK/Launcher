using Faj.Common.Model.Static.PlayerInitialize.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Common.Model.Static.PlayerInitialize.Collection.Item
{
    struct PlayerInitializeItem : IPlayerInitializeItem
	{
        readonly Dictionary<string, int> resources;
        readonly string startLevel;

        public PlayerInitializeItem(Dictionary<string, int> resources, string startLevel)
        {
            this.resources = resources;
            this.startLevel = startLevel;
        }

        public Dictionary<string, int> GetResources()
        {
            return resources;
        }

        public string GetStartLevel()
        {
            return startLevel;
        }
	}
}
