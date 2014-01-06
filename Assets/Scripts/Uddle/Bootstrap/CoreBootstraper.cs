using System;
using Uddle.Bootstrap.Interface;
using Uddle.Config.Interface;

namespace Uddle.Bootstrap
{
    abstract class CoreBootstraper : ICoreBootstraper
    {
        IBootstraper serviceBootstraper;
        IPackageBootstraper packagesBootstraper;        
        protected readonly IApplicationConfig applicationConfig;

        public CoreBootstraper(IApplicationConfig applicationConfig)
        {
            this.applicationConfig = applicationConfig;
            serviceBootstraper = new ServiceBootstraper(applicationConfig);
            serviceBootstraper.Bootstrap();
            packagesBootstraper = new PackageBootstraper(applicationConfig.GetPackagesXmlPath());
        }

        protected abstract void InitComponents();

        public void Bootstrap()
        {
            InitComponents();
            packagesBootstraper.Bootstrap();
        }

        public IPackageBootstraper GetPackageBootstraper()
        {
            return packagesBootstraper;
        }

        public IApplicationConfig GetApplicationConfig()
        {
            return applicationConfig;
        }
    }    
}
