using Uddle.Observer.Interface;
using Uddle.GUI.Render.Service.Interface;
using Uddle.GUI.Render.Interface;

namespace Uddle.GUI.Render.Service
{
    class GUIObserverService : IGUIObserverService
	{
        private IObserverCollection observerCollection;

        public GUIObserverService(IObserverCollection observerCollection)
        {
            this.observerCollection = observerCollection;
        }

        public void AddObserver(IGUIObserver observer)
        {
            this.observerCollection.AddObserver(observer);
        }

        public void RemoveObserver(IGUIObserver observer)
        {
            this.observerCollection.RemoveObserver(observer);
        }

        public void Notify()
        {
            this.observerCollection.Notify();
        }
	}
}
