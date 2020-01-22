namespace CosmosX.Entities.Reactors.ReactorFactory
{
    using Contracts;
    using Containers.Contracts;
    using Reactors.Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class ReactorFactory : IReactorFactory
    {
        private const string ReactorSuffix = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            var reactorType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(rt => rt.Name == reactorTypeName + ReactorSuffix);

            var reactor = Activator
                .CreateInstance(reactorType, new object[] { id, moduleContainer, additionalParameter }) as IReactor;

            if (reactor == null)
            {
                throw new ArgumentException($"Given reactor - {reactorTypeName} is not supported");
            }

            return reactor;
        }
    }
}
