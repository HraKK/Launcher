using Uddle.Static.Collection;
using Faj.Common.Static.Quest.Collection.Interface;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Quest.Collection
{
    class QuestCollection : TypicalStaticCollection<IQuestItem>, IQuestCollection
    {
        public List<IQuestItem> GetItemsByActionAndTarget(string action, string target)
        {
            List<IQuestItem> quests = new List<IQuestItem>();
            foreach (var item in items.Values)
            {
                if (item.GetAction() != action)
                {
                    continue;
                }

                if (item.GetTarget() != "" && item.GetTarget() != target)
                {
                    continue;
                }

                quests.Add(item);
            }

            return quests;
        }

        public List<IQuestItem> GetItemsByLevel(string level)
        {
            List<IQuestItem> quests = new List<IQuestItem>();
            foreach (var item in items.Values)
            {
                if (item.GetLevel() != level)
                {
                    continue;
                }

                quests.Add(item);
            }

            return quests;
        }
    }
}
