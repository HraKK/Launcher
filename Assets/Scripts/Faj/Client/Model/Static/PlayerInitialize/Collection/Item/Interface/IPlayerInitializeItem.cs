using Uddle.Static.Collection.Item;
using System.Collections.Generic;

namespace Faj.Client.Model.Static.PlayerInitialize.Collection.Item.Interface
{
	interface IPlayerInitializeItem : IStaticItem
	{
        Dictionary<string, int> GetResources();
	}
}
