using System;
using Uddle.Config.Interface;

namespace Uddle.Bootstrap.Interface
{
	interface ICoreBootstraper : IBootstraper
	{
        IApplicationConfig GetApplicationConfig();
        IPackageBootstraper GetPackageBootstraper();
	}
}
