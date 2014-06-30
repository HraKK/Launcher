using System.Collections.Generic;
using Uddle.Config.Interface;
using Uddle.Service;
using Uddle.GUI.Layout.Element.Interface;
using Uddle.GUI.Layout.Exception;
using Uddle.GUI.Render.Service.Interface;
using Uddle.GUI.Layout.Strategy.Interface;
using Uddle.GUI.Layout.Interface;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Layout
{
	abstract class AbstractLayout : ILayout
	{
        protected ILayoutStrategy layoutStrategy;

        readonly protected ApplicationPlatform platform;
        readonly protected IGUIObserverService GUIObserverService;

        List<IGUIElement> elements = new List<IGUIElement>();

        public AbstractLayout(ApplicationPlatform platform)
        {
            this.platform = platform;
            GUIObserverService = ServiceProvider.Instance.GetService<IGUIObserverService>();

            InitializeStrategy(platform);

            if (layoutStrategy == null)
            {
                throw new NoLayoutStrategyException();
            }

            layoutStrategy.DoInitializeStrategy();
        }

        public virtual void Draw()
        {
            layoutStrategy.DoStrategy();

            var elementsCount = elements.Count;

            for (int i = 0; i < elementsCount; i++)
            {
                elements[i].Render();
                //elements[i].SetHidden(false);
                //elements[i].SetEnabled(true);

            }
        }

        protected abstract void InitializeStrategy(ApplicationPlatform platform);

        public void AddElement(IGUIElement element)
        {
            element.OnHideEvent += new System.Action<IGUIElement>(OnHide);
            element.OnVisibleEvent += new System.Action<IGUIElement>(OnVisible);
            elements.Add(element);
        }

        void OnHide(IGUIElement element)
        {
            if (element is IObserver)
            {
                GUIObserverService.RemoveObserver(element as IObserver);
            }
        }

        void OnVisible(IGUIElement element)
        {
            if (element is IObserver)
            {
                GUIObserverService.AddObserver(element as IObserver);
            }
        }

        public void Display()
        {
            var elementsCount = elements.Count;

            for (int i = 0; i < elementsCount; i++)
            {
                elements[i].SetHidden(false);
            }
        }

        public void Hide()
        {
            var elementsCount = elements.Count;

            for (int i = 0; i < elementsCount; i++)
            {
                elements[i].SetHidden(true);
            }
        }

        void RemoveElements()
        {
            for (var i = 0; i < elements.Count; i++)
            {
                GUIObserverService.RemoveObserver(elements[i] as IObserver);
                elements[i].OnHideEvent -= new System.Action<IGUIElement>(OnHide);
                elements[i].OnVisibleEvent -= new System.Action<IGUIElement>(OnVisible);
                elements[i].SetHidden(false);
                elements[i].SetEnabled(false);
                elements[i].Disappear();                
                elements[i] = null;
            }

            elements.Clear();
        }

        public virtual void Disappear()
        {
            RemoveElements();
            layoutStrategy.DoDisappearStrategy();
        }
	}
}
