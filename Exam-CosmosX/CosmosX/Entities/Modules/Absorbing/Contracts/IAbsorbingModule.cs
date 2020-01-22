namespace CosmosX.Entities.Modules.Absorbing.Contracts
{
    using Modules.Contracts;

    public interface IAbsorbingModule : IModule
    {
        int HeatAbsorbing { get; }
    }
}