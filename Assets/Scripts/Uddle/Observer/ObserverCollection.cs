using Uddle.Observer.Interface;
using System.Collections.Generic;

namespace Uddle.Observer
{
	class ObserverCollection : IObserverCollection
	{
        protected int index = 0;
        protected int count = 0;

        protected List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            count = observers.Count;

            for (index = 0; index < count; index++)
            {
                observers[index].Notify();
            }
        }
	}
}