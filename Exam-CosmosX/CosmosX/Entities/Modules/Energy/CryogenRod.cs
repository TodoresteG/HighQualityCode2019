namespace CosmosX.Entities.Modules.Energy
{
    using Contracts;

    public class CryogenRod : BaseEnergyModule, IEnergyModule 
    {
        public CryogenRod(int id, int energyOutput)
            : base(id, energyOutput) 
        {
        }
    }
}