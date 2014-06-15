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

            
        }

        public void SetColor(UnityEngine.Color color)
        {
            style.normal.textColor = color;
            style.hover.textColor = color;            
        }

        protected virtual string GetText()
        {
            return text;
        }

        public void Notify()
        {
            if (true == isHidden)
            {
                return;
            }

            UnityEngine.GUI.Label(new Rect(x, y, width, height), GetText(), style);
        }
    }
}
