using Faj.Common.Static.Monster.Collection.Item.Interface;
namespace Faj.Common.Static.Monster.Collection.Item
{
	class MonsterItem : IMonsterItem
    {
        readonly string id;
        readonly string type;
        readonly int heals;

        public MonsterItem(string id, string type, int heals)
        {
            this.id = id;
            this.type = type;
            this.heals = heals;
        }

        public string GetId()
        {
            return id;
        }

        public string GetType()
        {
            return type;
        }

        public int GetHeals()
        {
            return heals;
        }
    }
}