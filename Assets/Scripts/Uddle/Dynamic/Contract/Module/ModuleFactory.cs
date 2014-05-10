using Uddle.Dynamic.Contract.Module.Interface;
using System.Collections.Generic;
using Uddle.Dynamic.Contract.Module.Exception;

namespace Uddle.Dynamic.Contract.Module
{
    class ModuleFactory : IModuleFactory
	{
        protected Dictionary<string, IContractModule> modules = new Dictionary<string,IContractModule>();

        public void AddModule(string name, IContractModule module)
        {
            modules.Add(name, module);
        }

        public IContractModule GetModule(string name)
        {
            IContractModule module;

            
            if (false == modules.TryGetValue(name, out module))
            {
                UnityEngine.Debug.Log(modules.Count);
                throw new NotExistModuleException("Module " + name + " not exist in dynamic contracts");
            }

            return module;
        }        
	}
}
