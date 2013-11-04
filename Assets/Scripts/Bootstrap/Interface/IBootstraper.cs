using System;
using UnityEngine;
using System.Collections;

namespace Application.Bootstrap.Interface
{
    public interface IBootstraper
    {
        void Init();

        event Action<int> OnDownloadPackagesStartEvent;
        event Action OnInitializeCompleteEvent;
        event Action OnDownloadedPackageEvent;
        event Action OnDownloadPackagesFinishEvent;
    }
}