using Faj.Common.Static.Perk.Collection.Item.Interface;

namespace Faj.Common.Static.Perk.Collection.Item
{
	struct PerkItem : IPerkItem
    {
        readonly string id;
        readonly string type;
        readonly string description;

        public PerkItem(string id, string type, string description)
        {
            this.id = id;
            this.type = type;
            this.description = description;
        }

        public string GetId()
        {
            return id;
        }

        public string GetType()
        {
            return type;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
