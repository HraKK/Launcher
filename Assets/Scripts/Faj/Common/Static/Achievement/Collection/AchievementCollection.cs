using Uddle.Static.Collection;
using Faj.Common.Static.Achievement.Collection.Item.Interface;
using Faj.Common.Static.Achievement.Collection.Interface;
using System.Collections.Generic;
using System;
namespace Faj.Common.Static.Achievement.Collection
{
    class AchievementCollection : TypicalStaticCollection<IAchievementItem>, IAchievementCollection
    {
        public List<IAchievementItem> GetItemsByActionAndTarget(string action, string target)
        {
            List<IAchievementItem> achievements = new List<IAchievementItem>();

            foreach (var item in items.Values)
            {
                if (item.GetAction() != action)
                {
                    continue;
                }

                if (false == String.IsNullOrEmpty(item.GetTarget()) && item.GetTarget() != target)
                {
                    continue;
                }

                achievements.Add(item);
            }

            return achievements;
        }
    }
}
