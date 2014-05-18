using Faj.Common.Static.Configuration.Collection.Item.Interface;

namespace Faj.Common.Static.Configuration.Collection.Item
{
    class ConfigurationItem : IConfigurationItem
	{
        readonly string id;
        readonly int value;

        public ConfigurationItem(string id, int value)
        {
            this.id = id;
            this.value = value;
        }

        public string GetId()
        {
            return id;
        }

        public int GetValue()
        {
            return value;
        }
	}
}
