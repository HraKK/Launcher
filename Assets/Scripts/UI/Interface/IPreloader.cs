using System;
using UnityEngine;
using System.Collections;

namespace Application.Preloader.Interface
{
    public interface IPreloader
    {
        event Action<int> OnTotalPackagesEvent;
        event Action<int> OnPackageDonwloadEvent;
    }
}