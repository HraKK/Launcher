using System.Collections;
using Uddle.GUI.Render.Interface;

namespace Uddle.GUISysytem
{
    abstract class GUIView : IGUIObserver
    {
        public void Notify()
        {
            Draw();
        }

        public virtual void Draw()
        {

        }
    }
}