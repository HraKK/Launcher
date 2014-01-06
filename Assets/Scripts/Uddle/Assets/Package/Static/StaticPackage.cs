using Uddle.Assets.Package.Static.Interface;

namespace Uddle.Assets.Package.Static
{
    struct StaticPackage : IStaticPackage
    {
        public StaticPackage(string name, string url, int version, PackageType type)
        {
            this._name = name;
            this._url = url;
            this._version = version;
            this._type = type;
        }

        public string name { get { return _name; } }
        public string url { get { return _url; } }
        public int version { get { return _version; } }
        public PackageType type { get { return _type; } }

        public readonly string _name;
        public readonly string _url;
        public readonly int _version;
        public readonly PackageType _type;
    }
}
