using Uddle.GUI.Layout.Element.Interface;
namespace Uddle.GUI.Layout.Interface
{
	interface ILayout
	{
        void AddElement(IGUIElement element);
        void Draw();
        void Display();
        void Hide();
        void Disappear();
	}
}
