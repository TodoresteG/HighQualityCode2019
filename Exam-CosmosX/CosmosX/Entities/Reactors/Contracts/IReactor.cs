namespace CosmosX.Entities.Reactors.Contracts
{
    using CommonContracts;
    using Modules.Absorbing.Contracts;
    using Modules.Energy.Contracts;

    public interface IReactor : IIdentifiable
    {
        long TotalEnergyOutput { get; }

        long TotalHeatAbsorbing { get; }

        int ModuleCount { get; }

        void AddEnergyModule(IEnergyModule energyModule);

        void AddAbsorbingModule(IAbsorbingModule absorbingModule);
    }
}