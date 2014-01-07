using Uddle.Service.Interface;
using Uddle.GUI.Render.Interface;

namespace Uddle.GUI.Render.Service.Interface
{
	interface IGUIObserverService : IService
	{
        void AddObserver(IGUIObserver observer);
        void RemoveObserver(IGUIObserver observer);
        void Notify();
	}
}
