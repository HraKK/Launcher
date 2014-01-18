using Uddle.Observer.Interface;
using Uddle.GUI.Render.Service.Interface;

namespace Uddle.GUI.Render.Service
{
    class GUIObserverService : IGUIObserverService
	{
        private IObserverCollection observerCollection;

        public GUIObserverService(IObserverCollection observerCollection)
        {
            this.observerCollection = observerCollection;
        }

        public void AddObserver(IObserver observer)
        {
            this.observerCollection.AddObserver(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observerCollection.RemoveObserver(observer);
        }

        public void Notify()
        {
            this.observerCollection.Notify();
        }
	}
}