using Uddle.Strategy.Interface;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace Faj.Client.Model.Preloader.Strategy
{
	class StaticPackageStrategy : IStrategy
	{
        public void DoStrategy()
        {
            UnityEngine.Debug.Log("static");
            var packageService = ServiceProvider.Instance.GetService<IPackageService>();
            var staticPackage = packageService.GetPackage("static");
            var xml = staticPackage.GetBundle().Load("item").ToString();
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            XDocument document = XDocument.Load(reader);
            UnityEngine.Debug.Log(document.Root.Element("data").Value);

        }
	}
}
