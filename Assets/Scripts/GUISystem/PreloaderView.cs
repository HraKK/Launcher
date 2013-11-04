using Application.GUISysytem.Interface;
using Application.Preloader.Interface;
using UnityEngine;

namespace Application.Preloader
{
    public class PreloaderView : IGUIView
    {
        private Texture2D background;
        private Texture2D loadProgress;
        private int totalPackages = 0;
        private int currentPackagesCount = 0;

        public PreloaderView(IPreloader preloader)
        {
            background = new Texture2D(1, 1);
            background.SetPixel(0, 0, Color.black);
            background.Resize(Screen.width, Screen.height);

            preloader.OnTotalPackagesEvent += OnTotalPackages;
            preloader.OnPackageDonwloadEvent += OnPackageDonwload;
        }

        private void OnPackageDonwload(int count)
        {
            currentPackagesCount = count;
        }

        private void OnTotalPackages(int count)
        {
            totalPackages = count;
        }

        public void Draw()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background, ScaleMode.ScaleToFit);
        }
    }
}