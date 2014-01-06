namespace Uddle.Observer.Interface
{
    interface IObserverCollection : IObserver
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }
}