using Uddle.Static.Collection;
using Faj.Common.Static.Level.Monster.Collection.Item.Interface;
using Faj.Common.Static.Level.Monster.Collection.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Level.Monster.Collection
{
    class LevelMonsterCollection : TypicalStaticCollection<ILevelMonsterItem>, ILevelMonsterCollection
    {
        public List<ILevelMonsterItem> GetMonstersByLevel(string levelId)
        {
            List<ILevelMonsterItem> monsters = new List<ILevelMonsterItem>();
            foreach (var item in items.Values)
            {
                if (item.GetLevelId() != levelId)
                {
                    continue;
                }

                monsters.Add(item);
            }

            return monsters;
        }
    }
}
