using Uddle.Assets.Interface;
using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Assets.Adapter.Interface;

namespace Uddle.Assets
{
    class DownloadPackage : IDownloadPackage
    {
        private readonly IDynamicPackage package;
        private readonly PackageDonwloadDelegate onPackageDownloaded;
        private int order;

        public DownloadPackage(IDynamicPackage package, PackageDonwloadDelegate onPackageDownloaded, int order)
        {
            this.package = package;
            this.onPackageDownloaded = onPackageDownloaded;
        }

        public int GetOrder()
        {
            return order;
        }

        public void SetMinOrder()
        {
            order = 0;
        }

        public void IncrementOrder()
        {
            order++;
        }

        public IDynamicPackage GetPackage()
        {
            return package;
        }

        public void Complete()
        {
            Result(true);
        }

        public void Failure()
        {
            Result(false);
        }

        private void Result(bool result)
        {
            onPackageDownloaded(true, package);
        }
    }
}