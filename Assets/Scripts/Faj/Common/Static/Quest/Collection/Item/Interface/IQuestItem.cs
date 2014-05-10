using Uddle.Static.Contract.Interface;

namespace Faj.Common.Static.Quest.Collection.Item.Interface
{
	interface IQuestItem : IStaticContract
    {
        string GetLevel();
        string GetAction();
        string GetTarget();
        int GetValue();
    }
}
