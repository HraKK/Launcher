using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Layout.Element.TextElement
{
    class TextElement : AbstractGUIElement, IObserver
    {
        protected string text;
        protected GUIStyle style;
        protected int width = 0;
        protected int height = 0;
        protected Rect position;
        
        public TextElement(string text)
            : base()
        {
            this.text = text;
            style = new GUIStyle();                        
        }

        public void SetFont(string font)
        {
            style.font = (Font)Resources.Load("Fonts/" + font, typeof(Font));
        }

        public void SetSize(int size)
        {
            style.fontSize = size;            
        }

        public virtual void SetPosition(float x, float y)
        {
            var dX = (screenWidth - Screen.width) / 2;
            this.x = x - dX;
            this.y = screenHeight - y;
            position = new Rect(this.x, this.y, width, height);
            
        }

        public void SetColor(UnityEngine.Color color)
        {
            style.normal.textColor = color;
            style.hover.textColor = color;            
        }

        public virtual void Notify()
        {
            if (true == isHidden || false == isEnabled)
            {
                return;
            }

            UnityEngine.GUI.Label(position, text, style);
        }
    }
}
