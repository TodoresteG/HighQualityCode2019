namespace CosmosX.Entities.Modules.Energy
{
    using Contracts;

    public abstract class BaseEnergyModule : BaseModule, IEnergyModule
    {
        protected BaseEnergyModule(int id, int energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public int EnergyOutput { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Energy Output: {this.EnergyOutput}";
        }
    }
}