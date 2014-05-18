using Uddle.Static.Contract.Interface;

namespace Faj.Common.Static.Level.Play.Collection.Item.Interface
{
	interface ILevelPlayItem : IStaticContract
    {
        int GetRate();
        string GetLevelId();
    }
}
