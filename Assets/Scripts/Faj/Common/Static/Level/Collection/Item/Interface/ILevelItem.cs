using Uddle.Static.Collection.Item;
using System.Collections.Generic;

namespace Faj.Common.Model.Static.Level.Collection.Item.Interface
{
    interface ILevelItem : IStaticItem
    {
        string GetId();
        string GetChapter();
        string GetType();
    }
}
