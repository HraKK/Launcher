using Uddle.Service.Interface;

namespace Uddle.Dynamic.Contract.Module.Interface
{
	interface IModuleFactory : IService
	{
        void AddModule(string name, IContractModule module);
        IContractModule GetModule(string name);
	}
}
