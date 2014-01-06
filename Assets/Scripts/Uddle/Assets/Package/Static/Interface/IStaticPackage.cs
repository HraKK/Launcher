namespace Uddle.Assets.Package.Static.Interface
{
	interface IStaticPackage
	{
        string name { get; }
        string url { get; }
        int version { get; }
        PackageType type { get; }
	}
}
