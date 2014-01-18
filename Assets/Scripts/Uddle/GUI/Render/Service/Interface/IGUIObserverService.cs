using Uddle.Service.Interface;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Render.Service.Interface
{
	interface IGUIObserverService : IService
	{
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notify();
	}
}
