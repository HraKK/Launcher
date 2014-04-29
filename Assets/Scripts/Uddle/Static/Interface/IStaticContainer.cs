using Uddle.Static.Collection.Interface;

namespace Uddle.Static.Interface
{
	interface IStaticContainer
	{
        void Initialize();
        IStaticCollection GetStaticCollection(string name);
        TStaticCollection GetStaticCollection<TStaticCollection>(string name) where TStaticCollection : IStaticCollection;
	}
}
