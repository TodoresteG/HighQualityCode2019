namespace CosmosX.Entities.Modules.Absorbing
{
    using Contracts;

    public class HeatProcessor : BaseAbsorbingModule, IAbsorbingModule
    {
        public HeatProcessor(int id, int heatAbsorbing) 
            : base(id, heatAbsorbing)
        {
        }
    }
}
