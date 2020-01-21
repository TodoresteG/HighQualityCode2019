using System;
using System.Linq;
using System.Reflection;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        private const string ReactorSuffix = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            var reactorType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == reactorTypeName + ReactorSuffix);

            if (reactorType == null)
            {
                throw new ArgumentException("Reactor type is not supported!");
            }

            IReactor reactor = (IReactor)Activator.CreateInstance(reactorType, id, moduleContainer, additionalParameter);

            return reactor;
        }
    }
}
