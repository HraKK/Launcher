using System.Collections.Generic;

namespace Uddle.Assets.Package.Static.Interface
{
	interface IStaticPackages
	{
        List<IStaticPackage> GetPackagesByType(PackageType packageType);
	}
}
