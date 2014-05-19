using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Monster.Collection.Item.Interface
{
    interface IMonsterItem : IStaticItem
    {
        string GetId();
        string GetType();
        int GetHeals();
    }
}
