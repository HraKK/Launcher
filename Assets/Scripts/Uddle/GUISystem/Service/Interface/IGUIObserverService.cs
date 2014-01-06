using Uddle.Service.Interface;
using Uddle.GUISysytem.Interface;

namespace Uddle.GUISysytem.Service.Interface
{
	interface IGUIObserverService : IService
	{
        void AddObserver(IGUIObserver observer);
        void RemoveObserver(IGUIObserver observer);
        void Notify();
	}
}
