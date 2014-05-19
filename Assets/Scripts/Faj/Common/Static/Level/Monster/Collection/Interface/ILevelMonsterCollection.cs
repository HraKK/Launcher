using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Level.Monster.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Level.Monster.Collection.Interface
{
	interface ILevelMonsterCollection : IStaticGenericCollection<ILevelMonsterItem>
	{
        List<ILevelMonsterItem> GetMonstersByLevel(string levelId);
	}
}
