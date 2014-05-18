using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Configuration.Collection.Item.Interface
{
    interface IConfigurationItem : IStaticItem
	{
        string GetId();
        int GetValue();
	}
}
