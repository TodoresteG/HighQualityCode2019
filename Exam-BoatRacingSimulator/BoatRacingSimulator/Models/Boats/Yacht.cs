namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public class Yacht : MotorBoat
    {
        private IBoatEngine boatEngine;
        private int cargoWeight;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine boatEngine)
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.boatEngine = boatEngine;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.boatEngine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);

            return speed;
        }
    }
}
