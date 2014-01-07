using System;

namespace Uddle.Dependency.Interface
{
	interface IDependencyAwaiter
	{
        event Action OnDependenciesReleaseEvent;
        void AddDependency(IDependency dependecy);
	}
}
