using Uddle.Assets.Package.Dynamic.Interface;

namespace Uddle.Assets.Interface
{
	interface IDownloadPackage
	{
        int GetOrder();
        void SetMinOrder();
        void IncrementOrder();
        IDynamicPackage GetPackage();
        void Complete();
        void Failure();
	}
}
