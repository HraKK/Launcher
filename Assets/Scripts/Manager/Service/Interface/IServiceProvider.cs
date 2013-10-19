namespace Application.Manager.Service.Interface
{
    public interface IServiceProvider
    {
        T GetService<T>();
        void SetService<T>(IService service);
    }
}