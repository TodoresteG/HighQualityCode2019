using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

       
        public override long TotalEnergyOutput
        {
            get
            {
                //TODO don't know what to do here
                if (this.TotalHeatAbsorbing < base.TotalEnergyOutput)
                {
                    return  0;
                }

                return base.TotalEnergyOutput;
            }
        }

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}