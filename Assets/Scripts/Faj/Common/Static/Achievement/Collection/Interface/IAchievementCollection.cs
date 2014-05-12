using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Achievement.Collection.Item.Interface;
using System.Collections.Generic;
namespace Faj.Common.Static.Achievement.Collection.Interface
{
    interface IAchievementCollection : IStaticGenericCollection<IAchievementItem>
    {
        List<IAchievementItem> GetItemsByActionAndTarget(string action, string target);
    }
}
