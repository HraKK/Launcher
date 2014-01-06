using Uddle.Static.Collection.Interface;
using System.Xml.Linq;

namespace Uddle.Static.Parser.Interface
{
	interface IStaticParser
	{
        IStaticCollection Parse(XDocument document);
	}
}
