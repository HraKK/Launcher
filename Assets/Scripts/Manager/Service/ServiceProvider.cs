using System.Collections.Generic;
using Application.Manager.Service.Interface;

namespace Application.Manager.Service
{
	public class ServiceProvider : IServiceProvider
    {
        static IServiceProvider instance;

        static public IServiceProvider Instance
        {
            get { if (null == instance) instance = new ServiceProvider(); return instance; }
        }

        ServiceProvider() { }

        Dictionary<string, IService> services = new Dictionary<string, IService>();

        public T GetService<T>()
        {
            var serviceName = typeof(T).ToString();
            if (!services.ContainsKey(serviceName))
            {
                throw new NotRegisteredServiceException("Not registered service: " + serviceName);
            }

            return (T)services[serviceName];
        }

        public void SetService<T>(IService service)
        {            
            services.Add(typeof(T).ToString(), service);
        }
    }
}
