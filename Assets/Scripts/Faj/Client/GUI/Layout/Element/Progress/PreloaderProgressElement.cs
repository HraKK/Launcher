using Uddle.GUI.Layout.Element;
using UnityEngine;
using Uddle.Observer.Interface;
using Uddle.Model.Preloader.Interface;

namespace Faj.Client.GUI.Layout.Element.Progress
{
	class PreloaderProgressElement : AbstractGUIElement, IObserver
	{
        float progress = 0;
        int totalDependencyCount = 0;
        int dependencyReleasedCount = 0;
        float timeOnDependency = 20;
        float timePassed = 0;
        readonly IPreloaderModel preloaderModel;

        public PreloaderProgressElement(Sprite sprite, IPreloaderModel preloaderModel)
            : base()
        {
            this.preloaderModel = preloaderModel;
            spriteRenderer.sprite = sprite;
            preloaderModel.OnTotalDependencyEvent += new System.Action<int>(OnTotalDependency);
            preloaderModel.OnDependencyReleaseEvent += new System.Action<int>(OnDependencyRelease);
        }

        public override void Disappear()
        {            
            preloaderModel.OnTotalDependencyEvent -= new System.Action<int>(OnTotalDependency);
            preloaderModel.OnDependencyReleaseEvent -= new System.Action<int>(OnDependencyRelease);
            base.Disappear();
        }

        void OnDependencyRelease(int dependencyReleasedCount)
        {
            this.dependencyReleasedCount = dependencyReleasedCount;
            CalculateTimeOnDependency();
        }

        void CalculateTimeOnDependency()
        {
            timeOnDependency = timePassed / dependencyReleasedCount;
        }

        void OnTotalDependency(int totalDependencyCount)
        {
            this.totalDependencyCount = totalDependencyCount;
        }

        public void Notify () 
        {
            timePassed += Time.deltaTime;

            if (IsProgressAwaiting())
            {
                return;
            }
            this.progress += (100 / (totalDependencyCount * timeOnDependency))  * Time.deltaTime;
            var scale = spriteRenderer.transform.localScale;
            scale.x = progress * 4;
            spriteRenderer.transform.localScale = scale;            
        }

        bool IsProgressAwaiting()
        {
            if (totalDependencyCount == 0)
            {
                return true;
            }

            if ((float)(dependencyReleasedCount + 1) / (totalDependencyCount + 1) * 100 > progress)
            {
                return false;
            }

            return true;
        }
	}
}
