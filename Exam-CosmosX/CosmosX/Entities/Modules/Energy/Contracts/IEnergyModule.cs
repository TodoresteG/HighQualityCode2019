namespace CosmosX.Entities.Modules.Energy.Contracts
{
    using Modules.Contracts;

    public interface IEnergyModule : IModule
    {
        int EnergyOutput { get; }
    }
}