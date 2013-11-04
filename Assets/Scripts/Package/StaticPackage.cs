namespace Application.GamePackages
{
    public struct StaticPackage
    {
        public StaticPackage(string name, string url, int version, PackageType type)
        {
            this.name = name;
            this.url = url;
            this.version = version;
            this.type = type;
        }

        public readonly string name;
        public readonly string url;
        public readonly int version;
        public readonly PackageType type;
    }
}
