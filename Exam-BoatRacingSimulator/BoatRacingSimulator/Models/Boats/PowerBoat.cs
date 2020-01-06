namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;

    using System.Linq;
    using System.Collections.Generic;

    public class PowerBoat : MotorBoat
    {
        private List<IBoatEngine> boatEngines;

        public PowerBoat(string model, int weight, List<IBoatEngine> boatEngines)
            : base(model, weight)
        {
            this.boatEngines = boatEngines;
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.boatEngines.Sum(x => x.Output) - this.Weight + (race.OceanCurrentSpeed / 5d);
            
            return speed;
        }
    }
}
