using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Modules.Factories;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;

namespace CosmosX.Core
{
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

            IReactor reactor =
                this.reactorFactory.CreateReactor(reactorType, this.currentId, container, additionalParameter);

            this.reactors.Add(reactor.Id, reactor);

            this.identifiableObjects.Add(reactor.Id, reactor);

            this.currentId++;

            string result = string.Format(Constants.ReactorCreateMessage, reactor.Id, reactorType);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            IModule module = this.moduleFactory.CreateModule(moduleType, this.currentId, additionalParameter);

            IReactor reactor = this.reactors[reactorId];

            IAbsorbingModule absorbing = module as IAbsorbingModule;

            if (absorbing != null)
            {
                reactor.AddAbsorbingModule(absorbing);
            }
            else
            {
                reactor.AddEnergyModule((IEnergyModule)module);
            }

            this.modules.Add(this.currentId, module);
            this.identifiableObjects.Add(this.currentId, module);

            this.currentId++;

            string result = string.Format(Constants.ModuleCreateMessage, moduleType, module.Id, reactor.Id);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            if (this.reactors.ContainsKey(id))
            {
                IReactor reactor = this.reactors[id];

                return reactor.ToString();
            }
            else
            {
                IModule module = this.modules[id];

                return module.ToString();
            }
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
                .Count(x => x.GetType().BaseType.Name == nameof(BaseEnergyModule));

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m.GetType().BaseType.Name == nameof(BaseAbsorbingModule));

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +
                            $"Heat Reactors: {heatReactorCount}\n" +
                            $"Energy Modules: {energyModulesCount}\n" +
                            $"Absorbing Modules: {absorbingModulesCount}\n" +
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}";

            return result;
        }
    }
}