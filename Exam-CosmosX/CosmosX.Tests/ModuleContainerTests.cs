
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void AddEnergyModuleShouldAddModuleCorrectly()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            IEnergyModule energy = new CryogenRod(3, 10);

            moduleContainer.AddEnergyModule(energy);

            int expected = 1;
            int actual = moduleContainer.ModulesByInput.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddEnergyModuleShouldThrowExceptionWhenModuleIsNull()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            Assert.Throws<ArgumentException>(() => moduleContainer.AddEnergyModule(null));
        }

        [Test]
        public void TotalEnergyOutputShouldReturnCorrectValue()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            IEnergyModule module = new CryogenRod(2, 5);

            moduleContainer.AddEnergyModule(module);

            var expected = 5;
            var actual = moduleContainer.TotalEnergyOutput;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAbsorbingModuleShouldAddModuleCorrectly()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            IAbsorbingModule module = new CooldownSystem(1, 6);
            IAbsorbingModule absorbing = new HeatProcessor(3, 3);

            moduleContainer.AddAbsorbingModule(module);
            moduleContainer.AddAbsorbingModule(absorbing);

            var expected = 2;
            var actual = moduleContainer.ModulesByInput.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAbsorbingModuleShouldThrowExceptionWhenModuleIsNull()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            Assert.Throws<ArgumentException>(() => moduleContainer.AddAbsorbingModule(null));
        }

        [Test]
        public void TotalHeatAbsorbingShouldReturnCorrectValue()
        {
            IContainer moduleContainer = new ModuleContainer(5);

            IAbsorbingModule module = new HeatProcessor(1, 4);

            moduleContainer.AddAbsorbingModule(module);

            var expected = 4;
            var actual = moduleContainer.TotalHeatAbsorbing;

            Assert.AreEqual(expected, actual);
        }
    }
}