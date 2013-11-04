using Application.Manager.Service.Interface;

namespace Application.GUISysytem.Interface
{
    public interface IGUISystem : IService
    {
        void AddView(IGUIView guiView);
        void RemoveView(IGUIView guiView);
        void Draw();
    }
}
