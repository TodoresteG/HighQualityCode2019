namespace CosmosX.Entities.Reactors.ReactorFactory.Contracts
{
    using Containers.Contracts;
    using Reactors.Contracts;

    public interface IReactorFactory
    {
        IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter);
    }
}