using Uddle.Model.Preloader.Interface;
using Uddle.Dependency.Interface;
using Uddle.GUISysytem.Interface;
using Uddle.GUISysytem.Service.Interface;
using System;
using Uddle.Service;

namespace Uddle.Model.Preloader
{
    abstract class AbstractPreloaderModel : IPreloaderModel, IDependencyAwaiter
    {        
        protected  IGUIObserver view;
        IGUIObserverService GUIObserverService;
        int totalDependenciesCount = 0;
        int currentDependenciesCount = 0;

        public event Action<int> OnTotalDependencyEvent;
        public event Action<int> OnDependencyReleaseEvent;

        public AbstractPreloaderModel()
        {
            InitializeView();
        }

        protected abstract void InitializeView();

        public void Initialize()
        {
            GetGUIOBserverService().AddObserver(view);
        }

        public void AddDependency(IDependency dependency)
        {
            totalDependenciesCount++;
            dependency.OnReleaseEvent += new Action<IDependency>(OnRelease);

            if (OnTotalDependencyEvent == null)
            {
                return;
            }

            OnTotalDependencyEvent(totalDependenciesCount);
        }

        void OnRelease(IDependency dependency)
        {
            dependency.OnReleaseEvent -= new Action<IDependency>(OnRelease);

            currentDependenciesCount++;
            /*
            
            */

            if (OnDependencyReleaseEvent != null)
            {
                OnDependencyReleaseEvent(currentDependenciesCount);
            }

            if (totalDependenciesCount == currentDependenciesCount)
            {
                Stop();
            }

            
        }

        IGUIObserverService GetGUIOBserverService()
        {
            if (GUIObserverService == null)
            {
                GUIObserverService = ServiceProvider.Instance.GetService<IGUIObserverService>();
            }

            return GUIObserverService;
        }           

        void OnDownloadPackage(string name)
        {
            
        }

        void Stop()
        {
            GetGUIOBserverService().RemoveObserver(view);        
        }
    }
}
