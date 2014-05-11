using Faj.Common.Static.Upgrade.Collection.Item.Interface;

namespace Faj.Common.Static.Upgrade.Collection.Item
{
    struct UpgradeItem : IUpgradeItem
    {
        readonly string id;
        readonly int level;
        readonly int value;

        public UpgradeItem(string id, int level, int value)
        {
            this.id = id;
            this.level = level;
            this.value = value;
        }

        public string GetId()
        {
            return id;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetValue()
        {
            return value;
        }
    }
}