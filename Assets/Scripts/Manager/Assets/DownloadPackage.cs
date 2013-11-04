using Application.GamePackages;
using Application.Manager.Assets.Interface;

namespace Application.Manager.Assets
{
    public class DownloadPackage
    {
        private readonly DynamicPackage package;
        private readonly PackageDonwloadDelegate onPackageDownloaded;
        private int order;

        public DownloadPackage(DynamicPackage package, PackageDonwloadDelegate onPackageDownloaded, int order)
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

        public DynamicPackage GetPackage()
        {
            return package;
        }

        public void OnDownloaded(bool result)
        {
            onPackageDownloaded(result, package.GetStaticPackage().name);
        }
    }
}