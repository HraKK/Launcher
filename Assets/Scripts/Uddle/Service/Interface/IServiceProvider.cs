namespace Uddle.Service.Interface
{
    interface IServiceProvider
    {
        T GetService<T>();
        void SetService<T>(IService service);
    }
}