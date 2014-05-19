using Faj.Common.Static.Level.Monster.Collection.Item.Interface;

namespace Faj.Common.Static.Level.Monster.Collection.Item
{
	class LevelMonsterItem : ILevelMonsterItem
	{
        readonly string id;
        readonly string levelId;
        readonly string monsterId;
        readonly int count;

        public LevelMonsterItem(string id, string levelId, string monsterId, int count)
        {
            this.id = id;
            this.levelId = levelId;
            this.monsterId = monsterId;
            this.count = count;
        }

        public string GetId()
        {
            return id;
        }

        public string GetLevelId()
        {
            return levelId;
        }

        public string GetMonsterId()
        {
            return monsterId;
        }

        public int GetCount()
        {
            return count;
        }
	}
}
