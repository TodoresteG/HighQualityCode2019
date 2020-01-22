namespace CosmosX.Entities.Modules.Absorbing
{
    using Contracts;

    public class CooldownSystem : BaseAbsorbingModule, IAbsorbingModule
    {
        public CooldownSystem(int id, int heatAbsorbing) 
            : base(id, heatAbsorbing)
        {
        }
    }
}
