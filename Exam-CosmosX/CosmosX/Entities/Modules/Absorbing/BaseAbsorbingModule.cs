namespace CosmosX.Entities.Modules.Absorbing
{
    using Contracts;

    public abstract class BaseAbsorbingModule : BaseModule, IAbsorbingModule
    {
        protected BaseAbsorbingModule(int id, int heatAbsorbing)
            : base(id)
        {
            this.HeatAbsorbing = heatAbsorbing;
        }

        public int HeatAbsorbing { get; }

        public override string ToString()
        {
            return base.ToString() + $"Heat Absorbing: {this.HeatAbsorbing}";
        }
    }
}