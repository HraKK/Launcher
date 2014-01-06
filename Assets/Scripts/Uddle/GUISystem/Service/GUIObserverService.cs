using Uddle.Observer.Interface;
using Uddle.GUISysytem.Interface;
using Uddle.GUISysytem.Service.Interface;

namespace Uddle.GUISysytem.Service
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
