using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Uddle.Assets.Package.Static.Interface;

namespace Uddle.Assets.Package.Static
{
	class StaticPackages : IStaticPackages
	{
        private Dictionary<string, IStaticPackage> packages;

        public StaticPackages(string xml)
        {
            ParseXML(xml);
        }

        public List<IStaticPackage> GetPackagesByType(PackageType packageType)
        {
            return packages.Values.Where(package => package.type == packageType).ToList();
        }

        private void ParseXML(string xml)
        {
            packages = new Dictionary<string, IStaticPackage>();

            var doc = XDocument.Parse(xml);
            if (doc.Root == null)
            {
                throw new Exception("Cant parse XML");
            }

            foreach (var packagesElement in doc.Root.Elements())
            {
                var packageStringType = (string)GetAttribute(packagesElement, "type");
                var packageType = (PackageType)Enum.Parse(typeof(PackageType), packageStringType);

                foreach (var packageElement in packagesElement.Elements())
                {
                    var packageName = packageElement.Value;
                    var packageVersion = (int)GetAttribute(packageElement, "version");
                    var packageUrl = (string)GetAttribute(packageElement, "path");

                    var package = new StaticPackage(packageName, packageUrl, packageVersion, packageType);
                    packages.Add(packageName, package);
                }
            }
        }

        private XAttribute GetAttribute(XElement element, string attributeName)
        {
            if (element.Attribute(attributeName) == null)
            {
                throw new Exception("Attribute " + attributeName + " not found.");
            }

            return element.Attribute(attributeName);
        }
	}
}