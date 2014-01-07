using System.Collections.Generic;
using Uddle.Config.Interface;
using Uddle.Service;
using Uddle.GUI.Layout.Element.Interface;
using Uddle.GUI.Layout.Exception;
using Uddle.GUI.Render.Service.Interface;
using Uddle.GUI.Layout.Strategy.Interface;
using Uddle.GUI.Layout.Interface;

namespace Uddle.GUI.Layout
{
	abstract class AbstractLayout : ILayout
	{
        protected ILayoutStrategy layoutStrategy;

        readonly protected ApplicationPlatform platform;

        List<IGUIElement> elements = new List<IGUIElement>();

        public AbstractLayout(ApplicationPlatform platform)
        {
            this.platform = platform;

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
                elements[i].SetEnabled(true);
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
        }

        void OnVisible(IGUIElement element)
        {
            
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

        public void Disappear()
        {
            elements.Clear();
            layoutStrategy.DoDisappearStrategy();
        }
	}
}
