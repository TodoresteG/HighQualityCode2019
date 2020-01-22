namespace CosmosX.Entities.Containers.Contracts
{
    using Modules.Absorbing.Contracts;
    using Modules.Contracts;
    using Modules.Energy.Contracts;

    using System.Collections.Generic;

    public interface IContainer
    {
        long TotalEnergyOutput { get; }

        long TotalHeatAbsorbing { get; }

        IReadOnlyCollection<IModule> ModulesByInput { get; }

        void AddEnergyModule(IEnergyModule energyModule);

        void AddAbsorbingModule(IAbsorbingModule absorbingModule);
    }
}