namespace Uddle.Static.Collection.Interface
{
	interface IStaticContainer
	{
        void Initialize();
        IStaticCollection GetStaticCollection(string name);
        TStaticItem GetStaticCollection<TStaticItem>(string name);
	}
}
