using Uddle.Assets.Package.Service.Interface;
using Uddle.Service;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Uddle.Service.Interface;
using Uddle.Assets.Package.Dynamic.Interface;
using System.Collections.Generic;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Exception;
using Faj.Common.Model.Static.PlayerInitialize.Collection.Interface;
using Faj.Common.Model.Static.PlayerInitialize.Collection;
using Uddle.Static.Parser.Interface;

namespace Uddle.Static
{
    abstract class StaticContainer : IStaticContainer
	{
        public const string STATIC_PACKAGE = "static";

        IServiceProvider serviceProvider;
        IPackageService packageService;
        IDynamicPackage staticPackage;
        bool isInitialized = false;

        protected Dictionary<string, IStaticCollection> staticCollections = new Dictionary<string, IStaticCollection>();

        public StaticContainer()
        {
            serviceProvider = ServiceProvider.Instance;
            packageService = serviceProvider.GetService<IPackageService>();
        }

        public void Initialize()
        {
            staticPackage = packageService.GetPackage(STATIC_PACKAGE);
            if (staticPackage == null)
            {
                throw new NotLoadedPackageException("Package not loaded: " + STATIC_PACKAGE);
            }

            InitializeCollections();
            isInitialized = true;
        }

        public IStaticCollection GetStaticCollection(string name)
        {
            if (isInitialized == false)
            {
                throw new NotInitializedContainerException();
            }

            IStaticCollection staticContainer;

            staticCollections.TryGetValue(name, out staticContainer);

            return staticContainer;
        }

        public TStaticCollection GetStaticCollection<TStaticCollection>(string name)
        {
            if (isInitialized == false)
            {
                throw new NotInitializedContainerException();
            }

            IStaticCollection staticCollection;

            staticCollections.TryGetValue(name, out staticCollection);

            return (TStaticCollection)staticCollection;
        }


        protected abstract void InitializeCollections();

        protected XDocument GetStaticDocument(string name)
        {
            var xml = staticPackage.GetBundle().Load(name).ToString();
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            return XDocument.Load(reader);
        }

        protected void addCollection(IStaticParser parser, string name)
        {
            var document = GetStaticDocument(name);
            var collection = parser.Parse(document);
            staticCollections.Add(name, collection);
        }
	}
}
