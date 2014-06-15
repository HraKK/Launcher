using Faj.Common.Static.Upgrade.Type.Collection.Item.Interface;

namespace Faj.Common.Static.Upgrade.Type.Collection.Item
{
    struct UpgradeTypeItem : IUpgradeTypeItem
    {
        readonly string id;
        readonly string description;
        readonly string category;

        public UpgradeTypeItem(string id, string description, string category)
        {
            this.id = id;
            this.description = description;
            this.category = category;
        }

        public string GetId()
        {
            return id;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetCategory()
        {
            return category;
        }
    }
}