using UnityEngine;
using Uddle.Model.Preloader.Interface;
using Uddle.GUISysytem;

namespace Faj.Client.Model.Preloader.View
{
    class PreloaderView : GUIView
    {
        private Texture2D background;
        private Texture2D loadProgress;

        private int totalPackages = 0;
        private int currentPackagesCount = 0;

        public PreloaderView(IPreloaderModel preloader)
        {
            background = new Texture2D(1, 1);
            background.SetPixel(0, 0, Color.black);
            background.Resize(Screen.width, Screen.height);

            preloader.OnTotalDependencyEvent += OnTotalPackages;
            preloader.OnDependencyReleaseEvent += OnPackageDownload;
        }

        private void OnPackageDownload(int count)
        {
            currentPackagesCount = count;
        }

        private void OnTotalPackages(int count)
        {
            totalPackages = count;
        }

        public override void Draw()
        {
//            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background, ScaleMode.ScaleToFit);
        }
    }
}