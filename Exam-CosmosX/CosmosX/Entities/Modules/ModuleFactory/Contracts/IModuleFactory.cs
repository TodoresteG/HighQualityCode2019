namespace CosmosX.Entities.Modules.ModuleFactory.Contracts
{
    using Modules.Contracts;

    public interface IModuleFactory
    {
        IModule CreateModule(string moduleType, int id, int additionalParameter);
    }
}
