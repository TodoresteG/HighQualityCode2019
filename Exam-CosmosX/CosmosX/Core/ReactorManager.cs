namespace CosmosX.Core
{
    using Contracts;
    using Entities.CommonContracts;
    using Entities.Containers;
    using Entities.Containers.Contracts;
    using Entities.Modules.Contracts;
    using Entities.Modules.Energy.Contracts;
    using Entities.Modules.Absorbing.Contracts;
    using Entities.Reactors;
    using Entities.Reactors.Contracts;
    using Entities.Reactors.ReactorFactory;
    using Entities.Reactors.ReactorFactory.Contracts;
    using Entities.Modules.ModuleFactory;
    using Entities.Modules.ModuleFactory.Contracts;
    using Utils;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;

        private readonly IReactorFactory reactorFactory;
        private readonly IModuleFactory moduleFactory;

        public ReactorManager()
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();

            this.reactorFactory = new ReactorFactory();
            this.moduleFactory = new ModuleFactory();
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            IReactor reactor = this.reactorFactory.CreateReactor(reactorType, this.currentId, container, additionalParameter);

            this.currentId++;

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);

            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            IModule module = this.moduleFactory.CreateModule(moduleType, this.currentId, additionalParameter);

            if (moduleType == "CryogenRod")
            {
                this.reactors[reactorId].AddEnergyModule((IEnergyModule)module);
            }
            else
            {
                this.reactors[reactorId].AddAbsorbingModule((IAbsorbingModule)module);
            }

            this.identifiableObjects.Add(module.Id, module);
            this.modules.Add(module.Id, module);

            this.currentId++;

            string result = string.Format(Constants.ModuleCreateMessage, moduleType, module.Id, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            var entityToReport = this.identifiableObjects[id];

            return entityToReport.ToString();
        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(CryoReactor));

            long heatReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(HeatReactor));

            long energyModulesCount = this.modules
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}" + Environment.NewLine +
                            $"Heat Reactors: {heatReactorCount}" + Environment.NewLine +
                            $"Energy Modules: {energyModulesCount}" + Environment.NewLine +
                            $"Absorbing Modules: {absorbingModulesCount}" + Environment.NewLine +
                            $"Total Energy Output: {totalEnergyOutput}" + Environment.NewLine +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}";

            return result;
        }
    }
}