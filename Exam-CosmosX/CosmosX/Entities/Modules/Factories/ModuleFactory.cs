using System;
using System.Linq;
using System.Reflection;
using CosmosX.Entities.Modules.Contracts;

namespace CosmosX.Entities.Modules.Factories
{
    public class ModuleFactory : IModuleFactory
    {
        public IModule CreateModule(string type, int id, int additionalParameter)
        {
            Type moduleType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (moduleType == null)
            {
                throw new ArgumentException("Module type not supported!");
            }

            IModule module = (IModule)Activator.CreateInstance(moduleType, id, additionalParameter);

            return module;
        }
    }
}
