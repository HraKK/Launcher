using System.Collections.Generic;
using Faj.Common.Model.Static.Level.Collection.Item.Interface;

namespace Faj.Common.Model.Static.Level.Collection.Item
{
    struct LevelItem : ILevelItem
    {
        readonly string id;
        readonly string chapter;
        readonly string type;

        public LevelItem(string id, string chapter, string type)
        {
            this.id = id;
            this.chapter = chapter;
            this.type = type;
        }

        public string GetId()
        {
            return id;
        }

        public string GetChapter()
        {
            return chapter;
        }

        public string GetType()
        {
            return type;
        }
    }
}
