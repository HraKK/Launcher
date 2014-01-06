using Uddle.GUISysytem.Interface;
using System.Collections;

namespace Uddle.GUISysytem
{
    public abstract class GUIView : IGUIObserver
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