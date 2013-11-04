using Application.Bootstrap;
using Application.GUISysytem.Interface;
using Application.Manager.Service;
using Application.UI;
using UnityEngine;
using System.Collections;

namespace Application
{
    public class Main : MonoBehaviour
    {
        private PreLoader preloader;
        private IGUISystem guiSystem;

        void Awake()
        {
            var bootstraper = new Bootstraper();
            bootstraper.Init();
            guiSystem = ServiceProvider.Instance.GetService<IGUISystem>();
        }

        void OnGUI()
        {
            guiSystem.Draw();
        }
    }
}
