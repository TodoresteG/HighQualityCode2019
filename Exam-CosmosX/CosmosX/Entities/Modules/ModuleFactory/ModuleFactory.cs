namespace CosmosX.Entities.Modules.ModuleFactory
{
    using Contracts;
    using Modules.Contracts;
    using Modules.Energy;
    using Modules.Absorbing;

    using System;
    using System.Linq;
    using System.Reflection;

    public class ModuleFactory : IModuleFactory
    {
        public IModule CreateModule(string moduleTypeName, int id, int additionalParameter)
        {
            var moduleType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(mt => mt.Name == moduleTypeName);

            var module = Activator
                .CreateInstance(moduleType, new object[] { id, additionalParameter }) as IModule;

            if (module == null)
            {
                throw new ArgumentException($"Given module {moduleTypeName} is not supported");
            }

            return module;
        }
    }
}
