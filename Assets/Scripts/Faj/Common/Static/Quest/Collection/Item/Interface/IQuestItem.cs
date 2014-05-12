using Uddle.Static.Contract.Interface;

namespace Faj.Common.Static.Quest.Collection.Item.Interface
{
    interface IQuestItem : IValuableItem
    {
        string GetLevel();
        string GetAction();
        string GetTarget();        
    }
}
