using System;

namespace Uddle.Model.Preloader.Interface
{
    interface IPreloaderModel
    {
        event Action<int> OnTotalDependencyEvent;
        event Action<int> OnDependencyReleaseEvent;

        void Initialize();
    }
}