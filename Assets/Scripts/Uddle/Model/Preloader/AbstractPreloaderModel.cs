using Uddle.Model.Preloader.Interface;
using Uddle.Dependency.Interface;
using System;
using Uddle.Service;
using Uddle.GUI.Render.Service.Interface;

namespace Uddle.Model.Preloader
{
    abstract class AbstractPreloaderModel : IPreloaderModel, IDependencyAwaiter
    {        
        int totalDependenciesCount = 0;
        int currentDependenciesCount = 0;

        public event Action<int> OnTotalDependencyEvent;
        public event Action<int> OnDependencyReleaseEvent;
        public event Action OnDependenciesReleaseEvent;

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

            if (OnDependencyReleaseEvent != null)
            {
                OnDependencyReleaseEvent(currentDependenciesCount);
            }

            if (totalDependenciesCount != currentDependenciesCount)
            {
                return;
            }

            if (OnDependenciesReleaseEvent != null)
            {
                OnDependenciesReleaseEvent();
            }
        }
    }
}
