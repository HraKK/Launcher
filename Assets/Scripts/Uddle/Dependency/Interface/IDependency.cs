using System;

namespace Uddle.Dependency.Interface
{
	interface IDependency
	{
        event Action<IDependency> OnReleaseEvent;
	}
}
