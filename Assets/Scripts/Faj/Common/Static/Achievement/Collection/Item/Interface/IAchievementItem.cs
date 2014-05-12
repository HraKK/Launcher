using Faj.Common.Static.Quest.Collection.Item.Interface;

namespace Faj.Common.Static.Achievement.Collection.Item.Interface
{
    interface IAchievementItem : IValuableItem
    {
        string GetAction();
        string GetTarget();
    }
}
