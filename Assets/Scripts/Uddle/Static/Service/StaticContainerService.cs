using Uddle.Static.Service.Interface;
using Uddle.Static.Collection.Interface;

namespace Uddle.Static.Service
{
    class StaticContainerService : IStaticContainerService
	{
        readonly IStaticContainer staticContainer;

        public StaticContainerService(IStaticContainer staticContainer)
        {
            this.staticContainer = staticContainer;
        }

        public TStaticCollection GetStaticCollection<TStaticCollection>(string name)
        {
            return staticContainer.GetStaticCollection<TStaticCollection>(name);
        }

        public IStaticCollection GetStaticCollection(string name)
        {
            return staticContainer.GetStaticCollection(name);
        }
	}
}
