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
            count = observers.Count;
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
            count = observers.Count;
        }

        public void Notify()
        {
            observers.ForEach(observer => observer.Notify());
            //for (index = 0; index < count; index++)
            //{
                //observers[index].Notify();
            //}
        }
	}
}