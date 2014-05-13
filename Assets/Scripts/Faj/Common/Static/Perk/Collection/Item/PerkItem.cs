using Faj.Common.Static.Perk.Collection.Item.Interface;

namespace Faj.Common.Static.Perk.Collection.Item
{
	struct PerkItem : IPerkItem
    {
        readonly string id;
        readonly string type;

        public PerkItem(string id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public string GetId()
        {
            return id;
        }

        public string GetType()
        {
            return type;
        }
    }
}
